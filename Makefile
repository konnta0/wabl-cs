NETWORK_NAME?=shared-network

WEB_APPLICATION_COMPOSE_YML=./docker-compose.yml
LOADTEST_COMPOSE_YML=./src/Tool/LoadTest/docker-compose.yml
GRAFANA_COMPOSE_YML=./o11y/docker-compose.grafana.yml

.PHONY: build
build:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) build --no-cache

.PHONY: up
up:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) up -d
	docker compose -f $(GRAFANA_COMPOSE_YML) up -d
	docker compose -f $(LOADTEST_COMPOSE_YML) up -d

.PHONY: ps
ps:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) ps -a
	docker compose -f $(GRAFANA_COMPOSE_YML) ps -a
	docker compose -f $(LOADTEST_COMPOSE_YML) ps -a

.PHONY: down
down:
	docker compose -f $(LOADTEST_COMPOSE_YML) down
	docker compose -f $(GRAFANA_COMPOSE_YML) down
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) down
	@if [ -n "`docker network inspect $(NETWORK_NAME) | grep \"\\"Containers\\": {}\"`" ]; then docker network rm $(NETWORK_NAME); fi

.PHONY: app-run
app-run:
	docker compose -f $(WEB_APPLICATION_COMPOSE_YML) up -d

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
	docker compose -f $(LOADTEST_COMPOSE_YML) build --no-cache

.PHONY: loadtest-up
loadtest-up:
	docker compose -f $(LOADTEST_COMPOSE_YML) up controller -d
	docker compose -f $(LOADTEST_COMPOSE_YML) up worker -d

.PHONY: loadtest-down
loadtest-down:
	docker compose -f $(LOADTEST_COMPOSE_YML) down controller
	docker compose -f $(LOADTEST_COMPOSE_YML) down worker

.PHONY: loadtest-run
loadtest-run:
	docker compose -f $(LOADTEST_COMPOSE_YML) up rest-api -d

.PHONY: loadtest-stop
loadtest-stop:
	docker compose -f $(LOADTEST_COMPOSE_YML) down rest-api

.PHONY: loadtest-log
loadtest-log:
	docker compose -f $(LOADTEST_COMPOSE_YML) logs -f

.PHONY: clean-image
clean-image:
	docker image prune -f