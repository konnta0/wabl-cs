NETWORK_NAME?=shared-network

WEB_APPLICATION_COMPOSE_YML=./docker-compose.yml
LOADTEST_COMPOSE_YML=./src/Tool/LoadTest/docker-compose.yml
GRAFANA_COMPOSE_YML=./o11y/docker-compose.grafana.yml

.PHONY: help # Show help
help:
	@grep '^.PHONY: .* #' Makefile | sed 's/\.PHONY: \(.*\) # \(.*\)/\1 ... \2/' | expand -t20

.PHONY: build # Build Web Application
build:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) build --no-cache

.PHONY: up # Up all components
up:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) up -d
	docker compose -f $(GRAFANA_COMPOSE_YML) up -d
	docker compose -f $(LOADTEST_COMPOSE_YML) up -d

.PHONY: ps # Show process
ps:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) ps -a
	docker compose -f $(GRAFANA_COMPOSE_YML) ps -a
	docker compose -f $(LOADTEST_COMPOSE_YML) ps -a

.PHONY: down # Down all components
down:
	docker compose -f $(LOADTEST_COMPOSE_YML) down --remove-orphans 
	docker compose -f $(GRAFANA_COMPOSE_YML) down --remove-orphans 
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) down --remove-orphans 
	@if [ -n "`docker network inspect $(NETWORK_NAME) | grep \"\\"Containers\\": {}\"`" ]; then docker network rm $(NETWORK_NAME); fi

.PHONY: app-run # Up Web Application
app-run:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) up -d

.PHONY: app-build # Build Web Application (No cache)
app-build:
	docker compose build app --no-cache

.PHONY: app-restart # Restart Web Application
app-restart:
	docker-compose kill app && docker-compose create app && docker-compose start app

.PHONY: app-log # Show log Web Application
app-log:
	docker compose logs -f app

.PHONY: app-db # Connect to Web Application Database
app-db:
	docker exec -it db mysql -u root -p

.PHONY: app-cache # Connect to Web Application Cache
app-cache:
	docker exec -it cache redis-cli

.PHONY: web-sh # Attach to Web Application
web-sh:
	docker compose exec app_web /bin/sh

.PHONY: metric-up # Up Metrics
metric-up:
	docker compose -f $(GRAFANA_COMPOSE_YML) up -d

.PHONY: metric-down # Down Metrics
metric-down:
	docker compose -f $(GRAFANA_COMPOSE_YML) down --remove-orphans 

.PHONY: metric-ps # Show process Metrics
metric-ps:
	docker compose -f $(GRAFANA_COMPOSE_YML) ps -a


.PHONY: loadtest-build # Build LoadTest Tool
loadtest-build:
	docker compose -f $(LOADTEST_COMPOSE_YML) build --no-cache

.PHONY: loadtest-up # Up LoadTest Tool
loadtest-up:
	docker compose -f $(LOADTEST_COMPOSE_YML) up controller -d
	docker compose -f $(LOADTEST_COMPOSE_YML) up worker -d

.PHONY: loadtest-down # Down LoadTest Tool
loadtest-down:
	docker compose -f $(LOADTEST_COMPOSE_YML) down controller --remove-orphans 
	docker compose -f $(LOADTEST_COMPOSE_YML) down worker --remove-orphans 

LOADTEST_WORKLOAD_NAME?=ListWorkload
LOADTEST_CONCURRENCY?=2
LOADTEST_TOTAL_REQUEST?=2

.PHONY: loadtest-run # Up LoadTest Tool (RestApi component)
loadtest-run:
	LOADTEST_WORKLOAD_NAME=$(LOADTEST_WORKLOAD_NAME) LOADTEST_CONCURRENCY=$(LOADTEST_CONCURRENCY) LOADTEST_TOTAL_REQUEST=$(LOADTEST_TOTAL_REQUEST) docker compose -f $(LOADTEST_COMPOSE_YML) up rest-api

.PHONY: loadtest-stop # Down LoadTest Tool (RestApi component)
loadtest-stop:
	docker compose -f $(LOADTEST_COMPOSE_YML) down rest-api --remove-orphans 

.PHONY: loadtest-log # Show log LoadTest Tool
loadtest-log:
	docker compose -f $(LOADTEST_COMPOSE_YML) logs -f

.PHONY: clean-image # Clean Unused Images
clean-image:
	docker image prune -f

ROOT_DIR=$(dir $(realpath $(firstword $(MAKEFILE_LIST))))
MIGRATION_COMMAND?=help

.PHONY: migration-add # Migration add. ex  make migration-add NAME=CreateTestTable
migration-add:
	docker build -f Dockerfile.DatabaseMigration -t database_migration .
	MIGRATION_COMMAND='migrations add'
	docker run -it \
	-v $(ROOT_DIR)src/Tool/DatabaseMigration:/src/Tool/DatabaseMigration \
	-v $(ROOT_DIR)src/WebApplication:/src/WebApplication \
	--env-file=.env \
	--name=database_migration \
	--rm \
	-w /src/Tool/DatabaseMigration \
	database_migration \
	dotnet ef migrations add $(NAME)

.PHONY: mount-dir #
mount-dir:
	mkdir -p $(PWD)/.data/mnt
	minikube mount $(PWD)/.data/mnt:/mnt

.PHONY: mk-start # 
mk-start: 
	mkdir -p $(PWD)/.data/mnt
	minikube start --memory='12g' --cpus=4 --driver=hyperkit --disk-size=40000mb --nodes=1 --insecure-registry="core.harbor.cr.test" --kubernetes-version v1.24.6 --mount --mount-string="$(PWD)/.data/mnt:/mnt"
	minikube addons enable ingress
	minikube addons enable ingress-dns
	minikube addons enable metrics-server
	#minikube node add --worker=true
	#minikube node add --worker=true

.PHONY: mk-stop # 
mk-stop:
	minikube stop

.PHONY: mk-dashboard # 
mk-dashboard:
	minikube dashboard

INFRASTRUCTURE_DIR=./src/Infrastructure
STACK?=develop
.PHONY: p-up # pulumi up
p-up:
	pulumi up --cwd $(INFRASTRUCTURE_DIR) -v=6 --stack $(STACK)

.PHONY: p-destroy # pulumi destroy
p-destroy:
	pulumi destroy --cwd $(INFRASTRUCTURE_DIR)

.PHONY: p-urns # pulumi urns
p-urns:
	pulumi stack --show-urns --cwd $(INFRASTRUCTURE_DIR)

.PHONY: p-delete # pulumi delete. (e.g.) URN=urn:pulumi:develop::Infrastructure::kubernetes:helm.sh/v3:Release::cert-manager make p-delete
p-delete:
	pulumi state delete $(URN) --cwd $(INFRASTRUCTURE_DIR)

.PHONY: p-output # pulumi stack output
p-output:
	pulumi stack output --cwd $(INFRASTRUCTURE_DIR)  

##### local setup command #####
.PHONY: install-minikube # see -> https://minikube.sigs.k8s.io/docs/start/
install-minikube:
	@echo "start install minikube"
	curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-darwin-amd64
	sudo install minikube-darwin-amd64 /usr/local/bin/minikube
	minikube version
	rm -f minikube-darwin-amd64
	@echo "end install minikube"

MINIKUBE_IP=$(shell minikube ip)
TEMPLATE_RESOLVER_MINIKUBE=makefile-resource/minikube-test
.PHONY: install-resolver-minikube
install-resolver-minikube: # https://minikube.sigs.k8s.io/docs/handbook/addons/ingress-dns/#mdns-reloading
	sudo mkdir -p /etc/resolver
	sed -e 's/MINIKUBE_IP/$(MINIKUBE_IP)/' $(TEMPLATE_RESOLVER_MINIKUBE) | sudo tee /etc/resolver/minikube-test

.PHONY: install-pulumi
install-pulumi:
	@echo "start install pulumi"
	curl -fsSL https://get.pulumi.com | sh
	@echo "end install pulumi"

DOMAIN=cr.test
CERTIFICATE_PATH=ca.crt
.PHONY: add-cert-into-docker
add-cert-into-docker: #
	@echo see https://matsuand.github.io/docs.docker.jp.onthefly/desktop/mac/#directory-structures-for-certificates
	sudo mkdir -p /etc/docker/certs.d/$(DOMAIN)/
	sudo cp -f $(CERTIFICATE_PATH) /etc/docker/certs.d/$(DOMAIN)/
	@echo please docker restart!!!!

SECRET_NAMESPACE=container-registry
SECRET_NAME=harbor-certificate
CERTIFICATE_NAME=ca.crt

.PHONY: get-cert # must set SECRET_NAMESPACE, SECRET_NAME, CERTIFICATE_NAME
get-cert:
	kubectl get secrets $(SECRET_NAME) -n $(SECRET_NAMESPACE) -o jsonpath='{.data.tls\.crt}' | base64 -D > $(CERTIFICATE_NAME)

.PHONY: add-cert # must set SECRET_NAMESPACE, SECRET_NAME, CERTIFICATE_NAME
add-cert: get-cert
	sudo security add-trusted-cert -d -r trustAsRoot -p ssl -k /Library/Keychains/System.keychain $(CERTIFICATE_NAME)

.PHONY: setup-local # 
setup-local: install-minikube install-pulumi
	@echo "start setup local"

.PHONY: build-image # 
build-image:
	docker build -t core.harbor.cr.test/webapp/dotnetapp:latest .

.PHONY: push-image # 
push-image: build-image
	docker image push core.harbor.cr.test/webapp/dotnetapp:latest