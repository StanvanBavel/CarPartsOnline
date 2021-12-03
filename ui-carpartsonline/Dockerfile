FROM node:lts-alpine as build-stage
WORKDIR /app
COPY ui-carpartsonline/package*.json ./
RUN ls-ls
RUN npm install
COPY ui-carpartsonline ./
RUN ls-ls
RUN npm run build
COPY ui-carpartsonline/nodeServer.js dist/nodeServer.js
WORKDIR /app/dist
EXPOSE 8080
CMD ["node", "nodeServer.js"]
