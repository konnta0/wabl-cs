.PHONY: up
up:
	docker compose up -d 

.PHONY: ps
ps:
	docker compose ps -a

.PHONY: down
down:
	docker compose down