NETWORK_NAME?=shared-network

.PHONY: build
build:
	docker compose build --no-cache

.PHONY: all
all:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f ./docker-compose.yml up -d
	docker compose -f ./metric/docker-compose.yml up -d

.PHONY: ps
ps:
	docker compose -f ./docker-compose.yml ps -a
	docker compose -f ./metric/docker-compose.yml ps -a

.PHONY: down
down:
	docker compose -f ./docker-compose.yml down
	docker compose -f ./metric/docker-compose.yml down
	@if [ -n "`docker network inspect $(NETWORK_NAME) | grep \"\\"Containers\\": {}\"`" ]; then docker network rm $(NETWORK_NAME); fi


.PHONY: app
app:
	docker compose -f ./docker-compose.yml up -d --build app

.PHONY: app-log
app-log:
	docker compose logs -f app

.PHONY: web-sh
web-sh:
	docker compose exec app_web /bin/sh

.PHONY: metric
metric:
	docker compose -f ./metric/docker-compose.yml up -d