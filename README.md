# MarceloAnimeList

This project is a simple web application that lists various anime titles.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Usage](#usage)

## Prerequisites

Before you can run this project, you need to have the following prerequisites installed:

- Docker: You'll need Docker to containerize the application and its dependencies.
- Docker Compose: This project uses Docker Compose for managing multiple Docker containers.

## Installation

To install just use the command:

```bash
docker-compose build
```

or create a database in docker with the command:

```bash
docker run -e "POSTGRES_PASSWORD=P@ssw0rd#2023" -p 5432:5432 --name postgres-local-container -d postgres:latest
```

then run visual studio 22
