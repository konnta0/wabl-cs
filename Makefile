.PHONY: build
build:
	docker compose build --no-cache

.PHONY: up
up:
	docker compose up -d
	docker compose exec app dotnet dev-certs https  

.PHONY: ps
ps:
	docker compose ps -a

.PHONY: down
down:
	docker compose down

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
