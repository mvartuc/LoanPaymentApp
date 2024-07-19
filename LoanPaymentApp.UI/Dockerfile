FROM node:alpine as build

WORKDIR /app

COPY . /app

RUN npm install @angular/cli@13.0.3

RUN npm install

EXPOSE 4200

RUN ./node_modules/.bin/ng build --prod
