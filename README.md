# SiiCarOrder

## Running whole application
To run all applications needed for functioning system you can use docker.

In root directory (where compose.yaml file is) run:

`docker compose up` <br>
That puts up all necessary dependencies and projects for the whole system.

By the compose file defaults, configurator frontend is available at port 8001, dealer frontend at 8002. Configurator and dealer backends are also exposed at 8081 and 8082 respectively as SPA frontend need to be able to reach them.

All other projects and architectural system like database are not exposed and reachable only through docker-compose internal network.
