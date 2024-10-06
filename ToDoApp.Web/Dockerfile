FROM node:latest AS build
WORKDIR /app/

COPY ./ToDoApp.Web/package*.json .
RUN npm ci
RUN npm i -g @angular/cli

COPY ./ToDoApp.Web/ .
RUN npm run build --configuration=production

FROM nginx:latest
COPY ./ToDoApp.Web/nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/to-do-app.web/browser/ /usr/share/nginx/html

EXPOSE 80
