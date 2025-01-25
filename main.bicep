@description('The name of the web app that you wish to create.')
param appName string = 'PoOnlineTest'

@description('Location for all resources.')
param location string = 'westus'

@description('The SKU of App Service Plan.')
param sku string = 'B1'

var appServicePlanName = '${appName}-plan'

// Create App Service Plan
resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: sku
  }
  kind: 'app'
}

// Create Web App
resource webApp 'Microsoft.Web/sites@2022-09-01' = {
  name: appName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          name: 'AzureOpenAI__Endpoint'
          value: 'https://poshared.openai.azure.com/'
        }
        {
          name: 'AzureOpenAI__Key'
          value: '6FlBrnPuXn2gUjyqVWiFFqu0Ma7I57TUavukI9ZixcaDFmNDhFVdJQQJ99BAACYeBjFXJ3w3AAABACOGIyFf'
        }
        {
          name: 'AzureOpenAI__DeploymentName'
          value: 'dall-e-3'
        }
      ]
      netFrameworkVersion: 'v8.0'
      metadata: [
        {
          name: 'CURRENT_STACK'
          value: 'dotnet'
        }
      ]
      windowsFxVersion: 'DOTNETCORE|8.0'
      alwaysOn: true
      minTlsVersion: '1.2'
    }
  }
}

// Output the website URL
output webAppUrl string = 'https://${webApp.properties.defaultHostName}'
