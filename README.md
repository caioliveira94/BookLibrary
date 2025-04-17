# Book Library Solution

This repository contains a simple Book Library application implemented with a .NET API (using CQRS and MediatR) and a Razor Pages frontend. The solution demonstrates:

API: .NET 7 Web API with EF Core, SQL Server, Docker, CQRS (MediatR).

Frontend: ASP.NET Core Razor Pages (.NET Web project) consuming the API.

Containerization: Dockerfile for the API.

Kubernetes: Example manifests under /BookLibrary.Api/k8s for deploying to AKS (Azure Kubernetes Service).

Prerequisites

.NET 7 SDK

SQL Server or Azure SQL

Docker Desktop

(Optional for Kubernetes)

kubectl CLI

Azure CLI

Local Development

1. Database Setup

By default the API uses LocalDB. Ensure your connection string in BookLibrary.Api/appsettings.json:

"ConnectionStrings": {
  "LibraryDb": "Server=(localdb)\\MSSQLLocalDB;Database=BookLibraryDb;Trusted_Connection=True;"
}

The seed data will run on startup causing EF Core to create the database and populate initial books.

2. Run API

cd BookLibrary.Api
# Restore and build
dotnet restore
dotnet build

# Run the API on http://localhost:5000 / https://localhost:5001
dotnet run

3. Run Frontend

cd BookLibrary.Web
# Restore and run
dotnet restore
dotnet run

Navigate to https://localhost:5002 (or the port shown) to view the Razor Pages UI.

Docker (API)

Build and run the API in a Docker container:

cd BookLibrary.Api
# Build image
docker build -t booklibraryapi:local .
# Run container
docker run -p 5000:80 booklibraryapi:local

The API will be available at http://localhost:5000.

Kubernetes Deployment (AKS)

If you want to demonstrate cloud deployment, use the provided Kubernetes manifests under /BookLibrary.Api/k8s.

Login to Azure & create resources

az login
az group create -n rg-booklib -l eastus
az acr create -n acrbooklibapi -g rg-booklib --sku Basic
az acr login -n acrbooklibapi

# Build & push image

docker build -f BookLibrary.Api/Dockerfile -t acrbooklibapi.azurecr.io/booklibraryapi:latest BookLibrary.Api
docker push acrbooklibapi.azurecr.io/booklibraryapi:latest

Create AKS & attach ACR

az aks create -n aks-booklib -g rg-booklib --node-count 2 --attach-acr acrbooklibapi --generate-ssh-keys
az aks get-credentials -n aks-booklib -g rg-booklib


2. **Apply manifests**

`bash
kubectl apply -f BookLibrary.Api/k8s/secret.yaml
kubectl apply -f BookLibrary.Api/k8s/deployment.yaml
kubectl apply -f BookLibrary.Api/k8s/service.yaml

Test

# Get external IP
kubectl get svc booklib-api-svc
curl http://<EXTERNAL-IP>/api/books/search?type=title&value=Pride

Summary

Clone this repository.

Follow the Local Development steps to run locally.

Use Docker commands to containerize the API.

Use Kubernetes manifests and Azure CLI to deploy on AKS.
