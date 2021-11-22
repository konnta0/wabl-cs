.PHONY: build
build:
	docker compose build --no-cache

.PHONY: up
up:
	docker compose up -d 

.PHONY: ps
ps:
	docker compose ps -a

.PHONY: down
down:
	docker compose down

.PHONY: bash
bash:
	docker compose exec -w /source app /bin/sh

.PHONY: app-build
app-build:
	docker compose exec -w /source app dotnet build

.PHONY: app-run
app-run:
	docker compose exec -w /source app dotnet run