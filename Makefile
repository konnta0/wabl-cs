NETWORK_NAME?=shared-network

.PHONY: build
build:
	docker compose build --no-cache

.PHONY: up
up:
	@if [ -z "`docker network ls | grep $(NETWORK_NAME)`" ]; then docker network create $(NETWORK_NAME); fi
	docker compose -f ./docker-compose.yml up -d
	docker compose -f ./docker-compose.yml exec app dotnet dev-certs https
	docker compose -f ./metric/docker-compose.yml up -d

.PHONY: ps
ps:
	docker compose ps -a

.PHONY: down
down:
	docker compose -f ./docker-compose.yml down
	docker compose -f ./metric/docker-compose.yml down
	@if [ -n "`docker network inspect $(NETWORK_NAME) | grep \"\\"Containers\\": {}\"`" ]; then docker network rm $(NETWORK_NAME); fi


.PHONY: app-sh
app-sh:
	docker compose exec -w /source app /bin/sh

.PHONY: app-build
app-build:
	docker compose exec -w /source app dotnet build

.PHONY: app-run
app-run:
	docker compose exec -w /source app dotnet run --no-build

.PHONY: web-sh
web-sh:
	docker compose exec app_web /bin/sh
