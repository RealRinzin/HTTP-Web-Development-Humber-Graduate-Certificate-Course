# Azure Virtual Network (VNet) — Simple Explanation for Full-Stack Developers

## Overview

**Azure Virtual Network (VNet)** is Azure’s way of giving you a **private network in the cloud**.  
It works like a home or office LAN, but for cloud resources such as APIs, databases, and servers.

You don’t pay to create a VNet — you pay only for the services that use it.

---

## Mental Model (Think Like a Developer)

- **VNet** → Your private network
- **Subnet** → Logical sections inside the network
- **Resources** → Servers, APIs, databases
- **NSG (Network Security Group)** → Firewall rules

> If you wouldn’t expose your database directly on the internet, you shouldn’t do it in Azure either.

---

## Basic Architecture (Beginner → Production)

### Virtual Network
```nginx
10.0.0.0/16
```

This is your private IP space in Azure.

---

## Subnet Layout (Separation of Concerns)

```nginx
Azure Virtual Network (10.0.0.0/16)
|
|-- Frontend Subnet  (10.0.1.0/24)
|-- Backend Subnet   (10.0.2.0/24)
|-- Database Subnet  (10.0.3.0/24)
```

---

## What Goes Where

### Frontend Subnet
```nginx
- React / Angular / Vue
- Public-facing
- Has a **Public IP**
- Entry point for users
```

### Backend Subnet
- Node.js / .NET / Java API
- **No public IP**
- Only accessible from the frontend subnet

### Database Subnet
- MySQL / PostgreSQL / SQL Server
- **Private only**
- No internet access at all

---

## How Traffic Flows

### 1. User Access
```nginx
User Browser
   ↓
Public IP
   ↓
Frontend App
```

---

### 2. Frontend → Backend
```nginx
Frontend (10.0.1.x)
   ↓ private network
Backend API (10.0.2.x)
```

---

### 3. Backend → Database
```nginx
Backend API (10.0.2.x)
   ↓ private network
Database (10.0.3.x)
```

---

## Network Security Groups (NSG)

### Frontend Subnet Rules

| Source     | Destination | Port    | Action |
|-----------|------------|---------|--------|
| Internet  | Frontend   | 80/443  | Allow  |
| Frontend  | Backend    | 443     | Allow  |

### Backend Subnet Rules

| Source     | Destination | Port   | Action |
|-----------|------------|--------|--------|
| Frontend  | Backend    | 443    | Allow  |
| Backend   | Database   | 3306   | Allow  |
| Internet  | Backend    | Any    | Deny   |

### Database Subnet Rules

| Source    | Destination | Port  | Action |
|----------|------------|-------|--------|
| Backend  | Database   | 3306  | Allow  |
| Internet | Database   | Any   | Deny   |

---

## With VNet vs Without VNet

| Without VNet     | With VNet        |
|-----------------|------------------|
| Public database | Private database |
| Weak security   | Strong security  |
| Demo only       | Production-ready |

---

## Cost Notes

- VNet creation: **Free**
- Subnets: **Free**
- You pay for VMs, databases, gateways, and data transfer

---

## One-Line Takeaway

> **Azure Virtual Network lets you build a secure, private backend architecture in the cloud.**
