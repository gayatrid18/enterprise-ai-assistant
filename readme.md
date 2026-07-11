# Enterprise AI Assistant

Enterprise AI Assistant is a Retrieval-Augmented Generation (RAG) based application that enables employees to ask natural language questions about internal company documents and receive AI-generated responses with supporting sources.

> **Project Status:** 🚧 In Progress

## Current Features

- ASP.NET Core Web API
- Health Check endpoint
- Chat endpoint
- Swagger/OpenAPI documentation
- Service layer with Dependency Injection
- Clean project structure

## Tech Stack

- ASP.NET Core 8
- C#
- Swagger / OpenAPI
- Dependency Injection

## Project Structure

```
EnterpriseAssistant.API
│
├── Controllers
├── Interfaces
├── Services
├── Models
├── Program.cs
```

## API Endpoints

### Health Check

```
GET /health
```

Returns the current health status of the API.

### Chat

```
POST /api/chat
```

Request

```json
{
  "question": "How many vacation days do I get?"
}
```

Response

```json
{
  "answer": "Employees receive 20 vacation days.",
  "source": "VacationPolicy.pdf"
}
```

> Currently returns a hardcoded response. AI integration will be added in future iterations.

## Roadmap

- [x] Health endpoint
- [x] Chat endpoint
- [x] Service layer
- [ ] Document upload
- [ ] PDF parsing
- [ ] Azure OpenAI integration
- [ ] Vector database
- [ ] Semantic search
- [ ] Authentication
- [ ] Docker
- [ ] Deployment

## Future Architecture

```
Client
   │
   ▼
ASP.NET Core API
   │
   ▼
Chat Service
   │
   ├── Azure OpenAI
   ├── Vector Database
   └── SQL Database
```

## Running the Project

```bash
git clone <repository-url>
cd EnterpriseAssistant.API
dotnet restore
dotnet run
```

Open Swagger:

```
https://localhost:<port>/swagger
```

## Purpose

This project is being developed to demonstrate production-style backend architecture, AI integration, system design concepts, and enterprise software engineering best practices.
