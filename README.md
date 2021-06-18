# SlotMachineApplication
A project which combines all aspects of fundamental training in QA.


This project will involve concepts from all core training modules; more
specifically, this will involve:

* Project Management
* C# Fundamentals
* Unit Testing
* Git
* Continuous Integration
* Software Development with C#
* Cloud Fundamentals
* Databases

## The Idea ##
The application is based on a traditional slot machine with an additional twist; a bonus number. The user will get a random combination of animals on a spin, there are prizes rewarded depending on the combination. The application will simulate a spin on the slot machine and the application idea incorporates multiple services working together to generate a 'random' prize for the user. 


## Requirements ##
The conception of this project involved setting up a clear structure of requirements. I undertook MoSCoW prioritization techniques to get started; this a common requirements management strategy for agile based development projects. I looked at project requirements under 4 scopes: **Must Have, Should Have, Could Have and Won't Have;** listed in descending order of priority.


#### MoSCoW Requirements Diagram ####

![MoSCoW Requirements Diagram](Images/Requirements.PNG)

In the four quadrants above, each represents one the prioritization categories, the **Must Have** section is the most important because it represents requirements which must be met in order to obtain a minimum viable product. The next step is representing the project requirements in a more development-digestible format using a **Kanban board**; the requirements will be broken down through **Stories and Epics**



## Analysis ##
The next phase of the project requires stringent risk analysis to decide on protocols in typical scenarios that may arise during the development life cycle. I created a **Risk Assessment Matrix** to represent and evaluate risks involved in the project going forward. These risks are assessed under the following headings: **Evaluation, Likelihood, Impact, Responsibility, Response and Control Measure.**


### Risk Assessment ###
These risks were formulated based on the technology stack required for the project and analysing what could go wrong in their interactions, there is a clear pattern of how these risks arise and what the approach to them will be.


#### Risk Assessment Matrix ####
|   Risk          | Evaluation | Likelihood| Impact  | Responsibility   |Response   | Control Measure  |
|:-------|:------|:---    |:---    |:-------|:------|:-----  |
| Application's virtual machine goes down | Application goes offline| Low | High | Cloud Service Provider  | Recreate infrastruture on another machine |  Use infrastructure as code to quickly recreate machine  |
| Broken version deployed onto production   | Application may not have all required features functional  |   Medium    | High | Developer     | Revert production to latest stable verion  | Automate tests before production push and restrict access to production branch      |
| DDOS attack    | Server goes down |    Medium    | High | Microsoft | Recreate infrastruture on another machine  |  Use infrastructure as code to quickly recreate machine   |
| High traffic    | Server requests could be unreliable/unavailable   |  Medium  | High| Developer  | Buy more azure server network allocation  | Ensure services are elastic|
| Data breach    | Customer data compromised   |   Medium    | Medium | Developer  | Notify relevant parties | Revise project access hierarchy and advise on latest security practices|
| Regional power outage     | Application goes offline   |    Low    | High | Cloud Service Provider  | Recreate infrastructure in another region  | Set up standby server in another region |
| Not delivering requirements on schedule    | Application wont meet minimum viable prodcut scope  |    Medium    | High | Developer  | Amend scheduled project delivery time   | Stick to minimum viable product scope as a first priority |


### User Stories ###
![Kanban](Images/Kanban.PNG)
Using Jira, the project requirements were tracked continuously using a kanban board which can be seen [here](https://darrendoyle.atlassian.net/jira/software/projects/SMA/boards/4 "Named link title"). The project tracking process was very simple and revolved around user stories which could either be frontend or backend related. A user story will usually outline a job that needs to be done from a developer or user perspective. I put all user stories on the backlog and when it was time to use them, I would put them on the kanban board. The kanban board has four simple stages: To Do, In Progress, Testing, Done. To Do means the story is yet to be taken up or worked on yet, this may be because of dependency on another user story. In Progress means the story is being worked on currently. Testing means the completed story is being analysed for any bugs, if it passes it moves to Done.


## Design ##
### Technologies Used ###
* Kanban Board: Jira
* Database: MySQL
* Programming languages: C#
* Version Control: Git
* CI Server: Azure Pipelines
* Cloud Platform: Azure
* Infrastructure as Code: Terraform
* Configuration Management: Ansible

![Application](Images/appplan.png)

This diagram give a general understanding of the development process for the application. The frontend and backend are developed on separate IDEs and pushed to a github repository. This repository can be accessed from the devops environment where automated scripts can be ran and tested constinuously through Pipelines. The app service will host the application. 


## Service 1 - Frontend ##
The frontend was designed using an Angular framework form javascript, this was stretch goal which was I felt was necessary to consolidate my learning. In the frontend I tried to showcase as much as I learned in training with the Ng module, Component-Orientated project structure, Directives and Observables.


### Database ###
![ERD](ERD.PNG)
There are two database tables which are Users and Posts. Users is the entity which represents a user on the system, they have a user account which permits them to create Posts. This relationship between the tables is a **One and Only One To Zero Or Many**, a user can none or many posts, while a post only belongs to a single User record if it exists. This establishes a UserID foreign key in the Posts table which establishes the link. Users will be able to use CRUD functionality on the post table through the application built on this database.


## Service 2 - Random Animals ## 
The backend was designed in ASP.Net Core, and was implemented as an API application which could be called from the frontend. This means it is acting as the middle-man between user experience and the relational MYSQL database. This API would have controllers for the Post and User table, handling the CRUD operations and returning JSON value to via HTTP requests. 
![Backend](Images/backendstructure.PNG)


### Service 3 - Bonus Number ###
The database of choice was MYSQL, which is hosted on an Azure Virtual Machine. To hook this up to the application we needed a connection string and appropriate Data models to represent the tables with in the database. 


### Service 4 - Merge Service ###
![user controller](Images/UserController.PNG)
The user controller is handling all operations related to the user table, there are methods written which return a JSON object. The methods written use Database Context in order to directly query the database and write logic in order to fulfil user requests. This includes a login, deletion and registration method.


## Testing ##
Extensive Unit testing was conducted on both controllers, ensuring operations were not returning incorrect types or null values. The controllers followed repository pattern best practices in order to provide a layer of encapsulation to the database. Code coverage was extensive on both controllers, I did not have view models in my project which might bring my percentage of coverage down (based on the coverage.json file). The tests carried out on the controller methods focused on return types and ensuring results were not null. 
![testing coverage](Images/finalcoverage.PNG)


## Terraform ##
The application was deployed with Azure DevOps using Azure pipelines. This set up allows for continuous deployment and integration of application builds while staying live in deployment. The application itself is being hosted on azure app service, with a virtual machine acting as a build agent. Below we can see the successful pipleline build of the application and subequent deployment to the app server. The devops project can be found [here](https://dev.azure.com/darrenadoyle/fifa-finder-project "Named link title")


## Ansible ##
The application was deployed with Azure DevOps using Azure pipelines. This set up allows for continuous deployment and integration of application builds while staying live in deployment. The application itself is being hosted on azure app service, with a virtual machine acting as a build agent. Below we can see the successful pipleline build of the application and subequent deployment to the app server. The devops project can be found [here](https://dev.azure.com/darrenadoyle/fifa-finder-project "Named link title")


## CI/CD Pipeline & Deployment ##
The application was deployed with Azure DevOps using Azure pipelines. This set up allows for continuous deployment and integration of application builds while staying live in deployment. The application itself is being hosted on azure app service, with a virtual machine acting as a build agent. Below we can see the successful pipleline build of the application and subequent deployment to the app server. The devops project can be found [here](https://dev.azure.com/darrenadoyle/fifa-finder-project "Named link title")


![Backend](Images/backenddeploy.PNG)


## What To Improve ## 
* The repository pattern was implemented too late and made project timing difficult, this had a knock on effect to other areas of the application.
* Based on the last step, there were issues parsing the user object back to the frontend, despite my best efforts using a data bind model to return the user ID for posts.
* Issues with deployment of the separate applications.



