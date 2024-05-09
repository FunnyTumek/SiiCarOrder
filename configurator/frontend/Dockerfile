FROM node:16 as build-env
WORKDIR /app
COPY package.json .
RUN npm install --legacy-peer-deps
COPY . .
ARG API_URL
ENV CONFIGURATOR_API_URL=$API_URL
RUN npm run build --prod

FROM nginx:1.23.1
COPY --from=build-env /app/build /usr/share/nginx/html
# We run a sed command to add to Nginx's default configuration a line
# in specific place to allow routing to work properly,
# as per https://www.serverlab.ca/tutorials/linux/web-servers-linux/how-to-configure-nginx-for-angular-and-reactjs/
RUN sed -i '9 a \ \ \ \ \ \ \ \ try_files $uri $uri/ /index.html?$args;' /etc/nginx/conf.d/default.conf
