# Stage 0, "build-stage", based on Node.js, to build and compile the frontend
FROM node:12.16.1 as build-stage
WORKDIR /app
COPY package*.json /app/
RUN yarn
COPY ./ /app/

RUN yarn build
# -- --output-path=./dist/out --configuration $configuration

# Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:1.15
#Copy ci-dashboard-dist
COPY --from=build-stage /app/dist/ /usr/share/nginx/html
#Copy default nginx configuration
COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf