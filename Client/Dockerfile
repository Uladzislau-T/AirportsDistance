FROM node:16-alpine as build
WORKDIR /app
COPY package.json /app/package.json
RUN npm install 
COPY . /app
RUN npm run build
FROM nginx:1.16.0-alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 3000
CMD ["nginx", "-g", "daemon off;"]