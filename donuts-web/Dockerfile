FROM node:14
LABEL author = "Eggert Mar Eggertsson eggerte19@ru.is"
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
#EXPOSE 8080
ENV DONUT_DBHOST="donut.kvyyq.mongodb.net"
ENV DONUT_DBNAME="myFirstDatabase"
ENV DONUT_DBUSER="admin"
ENV DONUT_DBPWD="admin"
EXPOSE 9000
CMD [ "npm", "start" ]


