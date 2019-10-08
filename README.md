# sample_egdn

This a sample EGDN Project that contains the following services:

* src/Services/Policy/ --> Policy Service ( Responsible for listing services and creating policies )
* src/Services/Identity/ --> Identity Service ( Responsible for Authentication and Authorization )
* src/Gateway/Gateway.WebApi/ --> Ocelot Gateway ( Responsible for proxying the REST Request to the services )
* src/Frameworks/Policy/ --> Shared Framework that contains all Auto-Mappers and entity framework implementation

# Policy Service
This service uses the Entity Framework code first approach in order to seed the MS-SQL DB and read/write different entities.
It exposes different REST APIs for retreiving services and creating Vehicle and Policies.
You can access the Swagger API documentation as http://localhost:8080/swagger/index.html

# Identity Service
This service is responsible for the Authentication & Authorization, currently the user accounts are hard coded into the code. That service is simulating the Auth0 Framework.
The built in accounts are as follows:
* test1 : test@123
* test2 : pass@123
* test3 : admin@123

A successful authentication from the Identity Service results of a JWT Token that can be then added to the "Authentication" headers in further requests.

# Gateway
This is the Ocelot gateway, it is designed to proxy and balance the requests between the different services.
It also handles the Authentication and the "Authentication" header to secure and verify the requests.

# Docker
docker-compose.yml file contains the following services:
* egdn-mssql: MSSQL instance for data persistance
* identity-api: Identity Service
* policy-api: Policy Service
* apigw: API Gateway

You can use the following commands:
* docker-compose build --> To build the entire solution
* docker-compose up --> In order to run the entire solution
* docker-compose push --> This command will push the built docker images to a local repo

You can access the API Gateway as http://localhost/api/v1/egdn

Below are some of the sample CURL requests:

curl -vvv -H "Content-Type: application/json"   -X POST http://localhost/user/authenticate -d '{"Username" : "test1", "Password" : "test@123"}'

That request will return the following JSON response:

{"auth_token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxIiwibmFtZSI6InRlc3QxIiwibmJmIjoxNTcwNTY4MDEzLCJleHAiOjE1NzExNzI4MTMsImlhdCI6MTU3MDU2ODAxM30.BFlV7Q_qrsV70Y27I3ztzFXE0E36aP8NdU3nQLy4ELk"}

This is the JWT Token that can be used in other requests

curl -X POST  -vvv -H "Content-Type: application/json" -H "authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiIxIiwibmFtZSI6InRlc3QxIiwibmJmIjoxNTcwNTY4MDEzLCJleHAiOjE1NzExNzI4MTMsImlhdCI6MTU3MDU2ODAxM30.BFlV7Q_qrsV70Y27I3ztzFXE0E36aP8NdU3nQLy4ELk"   -X GET http://localhost/api/v1/egdn/policy-services

That request will list the available Policy Services as JSON response:

[{"Name":"Service1","Price":5.0,"Period":10.00,"ServiceId":1},{"Name":"Service2","Price":6.0,"Period":20.00,"ServiceId":2},{"Name":"Service3","Price":4.0,"Period":25.00,"ServiceId":3}]



# AWS
For AWS Deployment we are using the following services:
* ECS with Fargate For Cluster management and Deployment as well as awsvpc for networking
* ECR for docker container registry
* CloudWatch for instance monitoring and logging
* VPC for network and subnets management

We have a different docker file "docker-compose_aws.yml" that is used to deploy to the AWS Cluster
We also have the "ecs-params.yml" file that have some specific AWS configurations to be used in the deployment.
The file "ecr-role.json" contains specific configurations that would allow the containers to pull the docker images from ECR

The following commands will be helpful assuming you have aws cli and ecs cli installed:

* Create a custer with the name "egdnsample"
ecs-cli configure --cluster egdnsample --default-launch-type FARGATE --region eu-west-2

* ecs-cli up --capability-iam
Bring the default cluster up

* aws ecr get-login --region eu-west-2 --no-include-email
Generate a temporary token to be used with the "docker login" command so that you can push the docker images to ECR

* docker-compose -f docker-compose_aws.yml push
Push the docker images to ECR

* Create & Assing roles
aws iam --region eu-west-2 create-role --role-name ecsTaskExecutionRole --assume-role-policy-document file:///opt/sample_egdn/execution-assume-role.json
aws iam --region eu-west-2 attach-role-policy --role-name ecsTaskExecutionRole --policy-arn arn:aws:iam::aws:policy/service-role/AmazonECSTaskExecutionRolePolicy

* Deploy the service to ECS
ecs-cli compose --file docker-compose_aws.yml --project-name egdn service up --enable-service-discovery --private-dns-namespace egdn --vpc vpc-0a26b947f019611b9

You'll notice that we are specifically mentioning the "docker-compose_aws.yml" file, while the "ecs-params.yml" file is not mentioned since it is being picked up by default.

Once you have executed the Deployment command you can access the instance through it's public IP





