NETWORK_NAME?=shared-network

.PHONY: build
build:
	docker compose build --no-cache

.PHONY: all
all:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f ./docker-compose.yml up -d
	docker compose -f ./o11y/docker-compose.grafana.yml up -d

.PHONY: ps
ps:
	docker compose -f ./docker-compose.yml ps -a
	docker compose -f ./o11y/docker-compose.grafana.yml ps -a

.PHONY: down
down:
	docker compose -f ./docker-compose.yml down
	docker compose -f ./o11y/docker-compose.grafana.yml down
	@if [ -n "`docker network inspect $(NETWORK_NAME) | grep \"\\"Containers\\": {}\"`" ]; then docker network rm $(NETWORK_NAME); fi


.PHONY: up
up:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f ./docker-compose.yml up -d

.PHONY: app
app:
	docker compose -f ./docker-compose.yml up -d

.PHONY: app-build
app-build:
	docker compose build app --no-cache

.PHONY: app-restart
app-restart:
	docker-compose kill app && docker-compose create app && docker-compose start app

.PHONY: app-log
app-log:
	docker compose logs -f app

.PHONY: app-db
app-db:
	docker exec -it db mysql -u root -p

.PHONY: app-cache
app-cache:
	docker exec -it cache redis-cli

.PHONY: web-sh
web-sh:
	docker compose exec app_web /bin/sh

.PHONY: metric
metric:
	docker compose -f ./o11y/docker-compose.grafana.yml up -d

.PHONY: loadtest-build
loadtest-build:
	docker compose -f ./docker-compose.loadtest.yml build --no-cache

.PHONY: loadtest-run
loadtest-run:
	docker compose -f ./docker-compose.loadtest.yml up -d

.PHONY: loadtest-log
loadtest-log:
	docker compose -f ./docker-compose.loadtest.yml logs -f

.PHONY: loadtest-stop
loadtest-stop:
	docker compose -f ./docker-compose.loadtest.yml down

.PHONY: clean-image
clean-image:
	docker image prune -f