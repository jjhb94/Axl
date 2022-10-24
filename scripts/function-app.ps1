## Create a new Azure resource group
resourcegroup=rgaxl0001dev
az group create --name rgaxl0001dev --location eastus

## Validate deployment and parameters
az deployment group validate \
--resource-group rgaxl0001dev \
--template-file function-app.json \
--parameters @function-app.parameters.json

az deployment group validate --resource-group rgaxl0001dev --template-file function-app.json --parameters @function-app.parameters.json


## Review the deployment without deploying
az deployment group what-if \
--name AxlFunctionAppDeployment \
--resource-group rgaxl0001dev \
--template-file function-app.json \
--parameters @function-app.parameters.json

az deployment group what-if --name AxlFunctionAppDeployment --resource-group rgaxl0001dev --template-file function-app.json --parameters @function-app.parameters.json

## Create a new deployment
az deployment group create \
--name AxlFunctionAppDeployment \
--resource-group $resourcegroup \
--template-file function-app.json \
--parameters @function-app.parameters.json

az deployment group create --name AxlFunctionAppDeployment --resource-group rgaxl0001dev --template-file function-app.json --parameters @function-app.parameters.json
