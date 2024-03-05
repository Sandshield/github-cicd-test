pipeline {
    agent {
        label 'dotnet'
    }
    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1' // Disable telemetry
    }

    stages {
        // stage('Checkout') {
        //     steps {
        //         // Checkout the source code from your version control system
        //         git 'https://github.com/yourusername/your-repository.git'
        //     }
        // }
        stage('Restore') {
            steps {
                // Restore dependencies using dotnet restore
                sh 'dotnet restore ./WeatherApi'
            }
        }
        stage('Build') {
            steps {
                // Build the project using dotnet build
                sh 'dotnet build --configuration Release ./WeatherApi'
            }
        }
        stage('Test') {
            steps {
                // Run tests using dotnet test
                sh 'dotnet test --configuration Release ./WeatherApi.Tests'
            }
        }
        stage('Image') {
            steps {
                //Build the docker image
                // sh 'docker login -u $DOCKER_HUB_USERNAME -p $DOCKER_HUB_PASSWORD'
                sh 'docker build -t wapi-jenkins-latest .'
                // Push the Docker image
                // sh 'docker login -u $DOCKER_HUB_USERNAME -p $DOCKER_HUB_PASSWORD'
                withCredentials([usernamePassword(credentialsId: 'docker-creds-id', usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                    sh "docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD"
                }
                
                sh 'docker push sandshield/heaven:wapi-jenkins-latest'

            }
        }
        // stage('Deploy') {
        //     steps {
        //         //Build the docker image
        //         // sh 'docker login -u $DOCKER_HUB_USERNAME -p $DOCKER_HUB_PASSWORD'
        //         sh 'docker build -t wapi-jenkins-latest .'
        //         // Push the Docker image
        //         // sh 'docker push sandshield/heaven:wapi-jenkins-latest'

        //     }
        // }
    }
}