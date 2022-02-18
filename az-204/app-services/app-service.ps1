az group create -n webapps-dev-rg -l centralus

az appservice plan create --name webapps-dev-plan `
  --resource-group webapps-dev-rg `
  --sku s1 `
  --is-linux
  
az webapp create -g webapps-dev-rg `
  -p webapps-dev-plan `
  -n mp10344884 `
  --runtime "node|10.14"