FROM node:lts-alpine as build-stage
WORKDIR /app
COPY package*.json ./
RUN ls -l
RUN npm install
COPY . ./
RUN ls -l
RUN npm run build
COPY nodeServer.js dist/nodeServer.js
WORKDIR /app/dist
EXPOSE 8080
CMD ["node", "nodeServer.js"]
