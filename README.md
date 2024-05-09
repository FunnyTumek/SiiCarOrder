# SiiCarOrder
Running part of the application
There are multiple compose files defined. The main compose.yaml spins up the whole application, but you can use the partial compose files to set up a part of the system.

Running architectural projects
docker compose -f compose-architecture.yaml up -d
# If you want to NOT run them in the background and be able to close them with CTRL+C, omit the `-d` flag
# docker compose -f compose-architecture.yaml up
You can spin up all architectural systems like database, mongodb or rabbitmq. They are defined to be accessible from localhost (in contrast to running them from compose.yaml), so you can start backend projects manually and locally and they will connect to the containers by themselves with no further configuration needed.

Running backend projects
There are 3 options as of right now to easily start backend projects:

You can use the partial compose file:

docker compose -f compose-backend.yaml up
# If you want to run them in the background, add the `-d` option:
# docker compose -f compose-backend.yaml up -d
Docker will spin up all backend project set up so that the connect to architectural systems That were previously spun up with these instructions.

You can use Visual Studio and the top-level solution file at src/SiiCarOrder.sln. In there you can set up multi-project startup and run all backend projects at once.

They are set up so they connect to the architectural system spun up with these instructions.

You can also use Visual Studio Code with the multi-root workspace defined at src/SiiCarOrder-backend.code-workspace.

That workspace has also defined tasks to build and launch debug versions of the project, so by CTRL+SHIFT+b you can build all backend projects and from Run and Debug tab you can start Launch all to spin up all projects in debug mode.

Running frontend projects
If you want to spin up both frontend projects you can use

docker compose -f compose-frontend.yaml up
# If you want to run them in the background, add the `-d` option:
# docker compose -f compose-backend.yaml up -d
This will spin up docker containers that will expose appropriate ports (8001 and 8002) to localhost and connect to backend projects that were previously spun up with one of the specified methods.
