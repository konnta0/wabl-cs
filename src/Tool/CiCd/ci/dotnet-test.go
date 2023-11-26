package main

import (
	"context"
	"os"

	"dagger.io/dagger"
)

func main() {
	ctx := context.Background()

	// initialize Dagger client
	client, err := dagger.Connect(ctx, dagger.WithLogOutput(os.Stdout))
	if err != nil {
		panic(err)
	}
	defer client.Close()

	golang := client.
		Container().
		From("mcr.microsoft.com/dotnet/sdk:8.0.100-1-alpine3.18").
		WithExec([]string{"dotnet", "test", "--no-restore", "--logger", "\"trx;LogFileName=test-results.trx\""})

	_, err = golang.Stdout(ctx)
	if err != nil {
		panic(err)
	}
}
