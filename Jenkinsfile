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
                sh 'dotnet test --configuration Release ./WeatherApi'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}