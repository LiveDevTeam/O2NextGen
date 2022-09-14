FROM node
WORKDIR  /app
COPY  package.json .
RUN npm install
COPY . .
ENV REACT_APP_NAME=myName 
EXPOSE 3300
CMD ["npm", "start"]  