 
Install kubectl
curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"

chmod +x kubectl
sudo mv kubectl /usr/local/bin/
kubectl version --client
================================================================

MINIKUBE 
#!/bin/bash

# ============================================
# UPDATE UBUNTU
# ============================================
sudo apt update && sudo apt upgrade -y

# ============================================
# INSTALL REQUIRED PACKAGES
# ============================================
sudo apt install -y \
    curl \
    wget \
    apt-transport-https \
    ca-certificates \
    gnupg \
    lsb-release

# ============================================
# INSTALL DOCKER
# ============================================

# Add Docker GPG key
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | \
sudo gpg --dearmor -o /usr/share/keyrings/docker.gpg

# Add Docker repository
echo \
  "deb [arch=$(dpkg --print-architecture) \
  signed-by=/usr/share/keyrings/docker.gpg] \
  https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Update package list
sudo apt update

# Install Docker
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Start Docker
sudo service docker start

# Enable Docker at startup
sudo systemctl enable docker

# Add current user to docker group
sudo usermod -aG docker $USER

echo "============================================"
echo "IMPORTANT:"
echo "After this script finishes, run:"
echo ""
echo "    wsl --shutdown"
echo ""
echo "Then reopen Ubuntu before continuing."
echo "============================================"

# ============================================
# INSTALL kubectl
# ============================================

curl -LO "https://dl.k8s.io/release/$(curl -L -s \
https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"

chmod +x kubectl

sudo mv kubectl /usr/local/bin/

# ============================================
# INSTALL MINIKUBE
# ============================================

curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64

chmod +x minikube-linux-amd64

sudo mv minikube-linux-amd64 /usr/local/bin/minikube

# ============================================
# VERIFY INSTALLATION
# ============================================

echo "============================================"
echo "Docker Version:"
docker --version

echo "============================================"
echo "kubectl Version:"
kubectl version --client

echo "============================================"
echo "Minikube Version:"
minikube version

echo "============================================"
echo "INSTALLATION FINISHED"
echo "============================================"
echo ""
echo "NEXT STEPS:"
echo ""
echo "1. Close Ubuntu"
echo "2. Run in Windows PowerShell:"
echo ""
echo "   wsl --shutdown"
echo ""
echo "3. Reopen Ubuntu"
echo ""
echo "4. Start Minikube:"
echo ""
echo "   minikube start --driver=docker"
echo ""
echo "5. Verify cluster:"
echo ""
echo "   kubectl get nodes"
echo ""

================================================================
minikube start --driver=docker
 
 
minikube status

kubectl get nodes

minikube delete

 
================================================================



API USERS 
================================================================
 1. Login to Docker Hub
docker login

# 2. Build the image
docker build -t your-dockerhub-username/apiusers:latest .


docker build -t lucaslearningsw/apiusers:latest .


# 3. Run locally to test
docker run --rm -p 8080:80 lucaslearningsw/apiusers:latest

# 4. Push to Docker Hub
docker push lucaslearningsw/apiusers:latest

http://localhost:8080/scalar/v1

http://localhost:8080/users



================================================================

API JOGOS 
================================================================
 1. Login to Docker Hub
docker login

# 2. Build the image
docker build -t your-dockerhub-username/apiusers:latest .


docker build -t lucaslearningsw/apijogos:latest .


# 3. Run locally to test
docker run --rm -p 8080:80 lucaslearningsw/apijogos:latest

# 4. Push to Docker Hub
docker push lucaslearningsw/apijogos:latest

http://localhost:8080/scalar/v1

http://localhost:8080/games



================================================================




kubectl apply -f namespace.yaml
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml



kubectl get ns

kubectl get pods -n apiusers

kubectl get svc -n apiusers


kubectl logs -n apiusers deployment/apiusers-deployment


kubectl port-forward svc/apiusers-service 8080:80 -n apiusers


================================================================



 