FROM node
WORKDIR  /app
COPY  package.json .
RUN npm install
COPY . .
ENV REACT_APP_NAME=myName 
EXPOSE 3400
CMD ["npm", "start"]  