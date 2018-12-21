sam package \
  --template-file template.yaml \
  --output-template debugging-example.yaml \
  --s3-bucket debugging-example-deploy

  sam deploy \
   --template-file debugging-example.yaml \
   --stack-name DebuggingExample \
   --capabilities CAPABILITY_IAM \
   --region eu-west-1

   dotnet lambda invoke-function DebuggingExample -–region eu-west-1