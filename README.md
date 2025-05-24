# MovieHub 🎬

MovieHub is a comprehensive movie management system built with ASP.NET Core 8.0, implementing the MVC architecture with Entity Framework Core. This application provides a robust platform for managing movies, actors, and producers in the film industry, featuring a clean architecture and modern web development practices.

## 🌟 Key Features

### Movie Management
- **Complete CRUD Operations**
  - Create new movies with detailed information
  - View movie listings with search and filter capabilities
  - Update movie details including cast and crew
  - Delete movies from the database
- **Movie Details**
  - Title, release date, and plot information
  - Genre and rating system
  - Cast information with actor relationships
  - Producer information
  - Movie posters and images

### Actor Management
- **Actor Profiles**
  - Personal information management
  - Filmography tracking
  - Gender classification
  - Biography and career details
- **Cast Management**
  - Assign actors to movies
  - View actor's movie history
  - Manage actor-movie relationships

### Producer Management
- **Producer Profiles**
  - Producer information management
  - Movie production history
  - Contact and professional details
- **Production Tracking**
  - Link producers with movies
  - Track production credits
  - Manage producer-movie relationships

## 🛠️ Technology Stack

### Backend
- **Framework:** ASP.NET Core 8.0
- **Database:** SQL Server with Entity Framework Core 8.0.6
- **Architecture:** 
  - MVC (Model-View-Controller)
  - Repository Pattern
  - Dependency Injection
- **Authentication:** Custom Authentication System

### Frontend
- **UI Framework:** ASP.NET Core MVC Views
- **Styling:** Bootstrap 5
- **JavaScript:** Modern ES6+
- **CSS:** Custom responsive design

## 📁 Project Structure

```
MovieHub/
├── Controllers/                 # MVC Controllers
│   ├── MovieController.cs      # Movie management
│   ├── ActorController.cs      # Actor management
│   ├── ProducerController.cs   # Producer management
│   └── HomeController.cs       # Home page and general views
│
├── Models/                     # Data Models
│   ├── Movie.cs               # Movie entity
│   ├── Actor.cs               # Actor entity
│   ├── Producer.cs            # Producer entity
│   ├── MovieActor.cs          # Movie-Actor relationship
│   ├── Gender.cs              # Gender enumeration
│   └── FilmIndustryDBContext.cs # Database context
│
├── Repository/                 # Data Access Layer
│   ├── IMovieRepository.cs    # Movie repository interface
│   ├── IActorRepository.cs    # Actor repository interface
│   ├── IProducerRepository.cs # Producer repository interface
│   └── [Implementation files] # Repository implementations
│
├── Views/                     # MVC Views
│   ├── Movie/                # Movie-related views
│   ├── Actor/                # Actor-related views
│   ├── Producer/             # Producer-related views
│   └── Shared/               # Shared layouts and partial views
│
├── wwwroot/                  # Static Files
│   ├── css/                 # Stylesheets
│   ├── js/                  # JavaScript files
│   └── images/              # Image assets
│
└── Migrations/              # Database Migrations
```

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server 2019 or later
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
   - Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```
   Access the application at:
   - Web Interface: `https://localhost:5001`
   - API Endpoints: `https://localhost:5001/api`

## 📚 API Endpoints

### Movies
- `GET /api/movies` - Get all movies
- `GET /api/movies/{id}` - Get movie by ID
- `POST /api/movies` - Create new movie
- `PUT /api/movies/{id}` - Update movie
- `DELETE /api/movies/{id}` - Delete movie

### Actors
- `GET /api/actors` - Get all actors
- `GET /api/actors/{id}` - Get actor by ID
- `POST /api/actors` - Create new actor
- `PUT /api/actors/{id}` - Update actor
- `DELETE /api/actors/{id}` - Delete actor

### Producers
- `GET /api/producers` - Get all producers
- `GET /api/producers/{id}` - Get producer by ID
- `POST /api/producers` - Create new producer
- `PUT /api/producers/{id}` - Update producer
- `DELETE /api/producers/{id}` - Delete producer

## 🔒 Authentication

The application implements a custom authentication system:
- User registration and login
- Role-based access control
- Secure password handling
- Session management
- Protected routes and endpoints

## 🏗️ Architecture

### Repository Pattern
- Abstracts data access layer
- Implements CRUD operations
- Provides clean separation of concerns
- Enables unit testing

### MVC Architecture
- Models: Data and business logic
- Views: User interface
- Controllers: Request handling and response

### Entity Framework Core
- Code-first approach
- Automatic migrations
- Relationship management
- Efficient querying

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Author

- **Harshil Patel** - *Initial work* - [Pharshil1910](https://github.com/Pharshil1910)

## 🙏 Acknowledgments

- Built with best practices in mind
- Inspired by modern movie management systems
- Thanks to the ASP.NET Core community
- Thanks to all contributors

---

⭐ Star this repository if you find it useful!

```
This `README.md` includes structured sections to guide users through setup, configuration, and running the application, along with a brief overview of its features and technology stack.

