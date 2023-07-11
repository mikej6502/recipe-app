pipeline {
    agent any
    tools {
            dotnet 'dotnet6'
        }
    environment {
        APP_NAME = 'RecipeApp'
        SCANNER_HOME = '/opt/sonar-scanner/bin'
    }        
    options {
        skipDefaultCheckout(true)
    }    
    stages {
        stage("Initialise") {
            steps {
                cleanWs()
                checkout scm
                sh 'dotnet restore'
            }
        }
        stage("Unit Tests") {
            steps {
                sh 'dotnet test --logger=trx'
            }
        }
        stage('Publish Unit Tests Report') {
            // install JenkinsCI XUnit plugin
            steps {
                  xunit (tools:[MSTest(pattern: '**/TestResults/*.trx')], skipPublishingChecks: false)
            }
        } 
        stage("SonarQube Analysis") {
            steps {
                sh 'dotnet build'
                sh 'dotnet test --no-build --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover'
            }
        }
        stage('Publish SonarQube Report') {
            steps {
                withSonarQubeEnv('SONARQUBE') {
                    sh '${SCANNER_HOME}/sonar-scanner -Dsonar.projectKey=${APP_NAME} -Dsonar.cs.opencover.reportsPaths="**/TestResults/*/*.xml"'
                }
            }
        }
    }
}