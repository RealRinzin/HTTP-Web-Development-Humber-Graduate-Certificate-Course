
> # Docker compose 

>### Step by step to deploy project with docker on cloud server
```docker
1. Buy VPS (Ubuntu)
2. Install Docker + Compose
3. Upload / clone project
4. Run: docker compose up -d
5. App is live 🚀
```

> # CI /CD 
> How CI/CD works with local code, github, server, docker image etc

```
You code
   ↓
git push
   ↓
GitHub Actions / GitLab CI
   ↓
Build Docker images
   ↓
Deploy to Ubuntu server
   ↓
docker compose up -d

```
## ✅ Mental Model (Easy Way to Remember)
| Part    | Job               |
| ------- | ----------------- |
| Ubuntu  | Runs Docker       |
| Docker  | Runs app          |
| Compose | Connects services |
| GitHub  | Stores code       |
| CI/CD   | Auto-deploy       |



