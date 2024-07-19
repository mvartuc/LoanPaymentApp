FROM node:alpine as build

WORKDIR /app

COPY ./package.json /app/package.json
RUN npm install
RUN npm install @angular/cli@13.0.4

COPY . /app/

RUN ./node_modules/.bin/ng build

# Stage 2: Serve the application with Nginx
FROM nginx:alpine AS serve

COPY --from=build /app/dist/StajProjesi /usr/share/nginx/html

# Custom Nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf.d/default.conf


EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
