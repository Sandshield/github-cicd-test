pipeline {
    agent {
        label 'dotnet' 'sshagent'
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
                
                // Tag the Docker image
                sh 'docker tag wapi-jenkins-latest sandshield/heaven:wapi-jenkins-latest'
                sh 'docker push sandshield/heaven:wapi-jenkins-latest'

            }
        }
        stage('Pull Docker Image') {
            steps {
                script {
                    // SSH into the remote server and pull the Docker image
                    sshagent(credentials: ['remote-ssh-creds-id']) {
                        sh 'ssh -o StrictHostKeyChecking=no agent@${env.REMOTE_USER} "docker pull sandshield/heaven:wapi-jenkins-latest"'
                    }
                }
            }
        }
        stage('Run Docker Container') {
            steps {
                script {
                    // SSH into the remote server and run the Docker container
                    sshagent(credentials: ['remote-ssh-creds-id']) {
                        sh 'ssh -o StrictHostKeyChecking=no agent@${env.REMOTE_USER} "docker run -d --name wapi-j-dc -p 5001:8080 sandshield/heaven:wapi-jenkins-latest"'
                    }
                }
            }
        }
    }
}
