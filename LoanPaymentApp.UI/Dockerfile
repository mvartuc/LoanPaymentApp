FROM node:alpine as build

WORKDIR /app

COPY ./package.json /app/package.json
RUN npm install
RUN npm install @angular/cli@13.0.4

COPY . /app/

RUN ./node_modules/.bin/ng build
