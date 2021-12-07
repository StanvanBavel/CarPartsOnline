FROM node:lts-alpine as build-stage
WORKDIR /app

ARG APP_URL="http://localhost:8080"
ENV VUE_APP_URL ${APP_URL}}

COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# production stage
FROM nginx:stable-alpine as production-stage
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]



# # Choose the Image which has Node installed already
# FROM node:lts-alpine

# # install simple http server for serving static content
# RUN npm install -g http-server

# # make the 'app' folder the current working directory
# WORKDIR /app

# # copy both 'package.json' and 'package-lock.json' (if available)
# COPY package*.json ./
# RUN ls -l
# # install project dependencies
# RUN npm install

# # copy project files and folders to the current working directory (i.e. 'app' folder)
# COPY . .

# # build app for production with minification
# RUN npm run build

# EXPOSE 8080
# CMD [ "http-server", "dist" ]


# FROM node:lts-alpine as build-stage
# WORKDIR /app
# COPY package*.json ./
# RUN ls -l
# RUN npm install
# COPY . ./
# RUN ls -l
# RUN npm run build
# COPY nodeServer.js /nodeServer.js
# WORKDIR /app/dist
# EXPOSE 8080
# CMD ["node", "nodeServer.js"]
