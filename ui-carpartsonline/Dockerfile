FROM ubuntu

MAINTAINER stanvanbavel pal <461345@student.fontys.nl>

RUN apt-get update

CMD ["echo", "Hello World...! from my first docker image!"]



# build stage
FROM node:lts-alpine as build-stage
WORKDIR /app/ui-carpartsonline


ARG APP_URL="http://localhost:8080"
ENV VUE_APP_URL ${APP_URL}}

COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# production stage
# FROM nginx:stable-alpine as production-stage
# COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
# COPY --from=build-stage /app/dist /usr/share/nginx/html
# EXPOSE 80
# CMD ["nginx", "-g", "daemon off;"]




# FROM node:lts-alpine as build-stage
# WORKDIR /app/ui-carpartsonline
# COPY package*.json ./
# RUN ls -l
# RUN npm install
# COPY . ./
# RUN ls -l
# RUN npm run build
# COPY nodeServer.js /nodeServer.js
# WORKDIR /app/ui-carpartsonline
# EXPOSE 8080
# CMD ["node", "nodeServer.js"]
