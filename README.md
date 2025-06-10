# Nibblr - WIP
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

**Nibblr** is built with ASP.NET and leverages OpenAI's API to enhance what would otherwise be another uninspired cookbook app. More than just a recipe collection, Nibblr intelligently manages your entire cooking workflow from discovery to shopping.

## Features

### 🤖 AI-Powered Recipe Extraction
Users can paste links to recipes found on the web and Nibblr will parse through the bloat and extract the ingredients, macros, and instructions before saving them to a recipe card. The AI cuts through recipe blog clutter, lengthy stories, and advertisements to identify the essential cooking information.

### 🥘 Smart Pantry Management
Nibblr intelligently manages your pantry inventory directly in the app. Track what ingredients you have on hand, monitor quantities, and get notified when items are running low.

### 🛒 Intelligent Shopping Lists
When viewing a recipe card, the app references your pantry to see what ingredients you have and offers to add any missing items to your shopping list. No more wondering what you need at the store or buying duplicates of items you already own.

### 📇 Recipe Organization
Create and manage your own custom recipes alongside AI-extracted ones. All recipes are stored as clean, structured cards with consistent formatting regardless of their source.

## 🚀 Getting Started

### Prerequisites

- .NET 6.0 or higher
- OpenAI API key

### Installation

```bash
git clone https://github.com/portbound/nibblrv2
cd nibblrv2
dotnet restore
```

### Configuration

Add your OpenAI API key to `appsettings.json`:

```json
{
  "OpenAI": {
    "ApiKey": "your_openai_api_key_here"
  }
}
```

### Running the Application

```bash
dotnet run
```

Navigate to `https://localhost:5001` to start using Nibblr.
