# MovieHub 🎬

MovieHub is a modern web application built with ASP.NET Core that provides a comprehensive solution for movie management and information. This application offers an intuitive interface for browsing, managing, and updating movie details, backed by a robust REST API.

## 🌟 Features

### Core Functionality
- **Movie Management**
  - Browse and search movies
  - Add new movies with detailed information
  - Edit existing movie details
  - Delete movies from the database
  - View detailed movie information

### Technical Features
- **RESTful API**
  - Complete CRUD operations
  - RESTful endpoints for movie management
  - JSON response format
  - Proper HTTP status codes and error handling

### Security
- **Authentication & Authorization**
  - Custom authentication system
  - Secure user access control
  - Protected routes and endpoints
  - User role management

### Data Management
- **Entity Framework Integration**
  - Efficient ORM implementation
  - Database migrations support
  - Optimized data queries
  - Relationship management

## 🛠️ Technology Stack

### Backend
- **Framework:** ASP.NET Core 7.0+
- **Architecture:** MVC (Model-View-Controller)
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Authentication:** Custom Authentication System

### Frontend
- **UI Framework:** ASP.NET Core MVC Views
- **Styling:** Bootstrap 5
- **JavaScript:** Modern ES6+
- **CSS:** Custom styles with responsive design

## 🚀 Getting Started

### Prerequisites
- .NET Core SDK 7.0 or later
- SQL Server (2019 or later)
- Visual Studio 2022 or VS Code
- Git

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Pharshil1910/MovieHub.git
   cd MovieHub
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Database Setup**
   - Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=MovieHubDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
   - Run database migrations:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```
   The application will be available at:
   - Web Interface: `https://localhost:5001`
   - API Endpoints: `https://localhost:5001/api`

## 📚 API Documentation

### Available Endpoints

#### Movies
- `GET /api/movies` - Get all movies
- `GET /api/movies/{id}` - Get movie by ID
- `POST /api/movies` - Create new movie
- `PUT /api/movies/{id}` - Update movie
- `DELETE /api/movies/{id}` - Delete movie

#### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/register` - User registration
- `POST /api/auth/logout` - User logout

## 🏗️ Project Structure

```
MovieHub/
├── Controllers/         # MVC Controllers
├── Models/             # Data Models
├── Views/              # MVC Views
├── Repository/         # Data Access Layer
├── Migrations/         # Database Migrations
├── wwwroot/           # Static Files
│   ├── css/          # Stylesheets
│   ├── js/           # JavaScript files
│   └── images/       # Image assets
└── Properties/        # Project Properties
```

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Harshil Kalsariya** - *Initial work* - [Pharshil1910](https://github.com/Pharshil1910)

## 🙏 Acknowledgments

- Thanks to all contributors who have helped shape this project
- Inspired by modern movie management systems
- Built with best practices in mind

---

⭐ Star this repository if you find it useful!

```
This `README.md` includes structured sections to guide users through setup, configuration, and running the application, along with a brief overview of its features and technology stack.

