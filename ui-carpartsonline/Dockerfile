FROM node:lts-alpine

# Create app directory
WORKDIR /app

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./

RUN npm install
# If you are building your code for production
# RUN npm ci --only=production

# Bundle app source
COPY . .

EXPOSE 8080
CMD [ "node", "server.js" ]




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
