FROM maven:3.9-sapmachine-17 AS build
COPY src /home/app/src
COPY pom.xml /home/app
RUN mvn -f /home/app/pom.xml clean package

FROM tomcat:11.0.0-jdk17
COPY --from=build /home/app/target/SEN300ECOMBasketServiceAPI.war /usr/local/tomcat/webapps/ROOT.war

ENV SERVER_PORT=8080
ENV REDIS_HOST=SEN300ECOMBasketServiceDBRedis
ENV REDIS_PORT=6379
ENV EUREKA_HOST=SEN300ECOMEurekaRegistry