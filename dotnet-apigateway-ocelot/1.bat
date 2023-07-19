CLS

docker stop SEN300ECOMAPIGatewayOcelot
docker rm SEN300ECOMAPIGatewayOcelot
docker rmi sen300ecomocelotgatewayapi:1
docker build --no-cache -t sen300ecomocelotgatewayapi:1 .
docker run -d -p 5041:8080 --name SEN300ECOMAPIGatewayOcelot --net netSEN300 sen300ecomocelotgatewayapi:1