# 🎮 Game Side Mobile

> A 2D mobile platformer with advanced movement mechanics, built with Unity 6 and Universal Render Pipeline.

**Read this in other languages:** [Persian (فارسی)](README_FA.md)

---

## 📋 Table of Contents

- [About](#-about)
- [Features](#-features)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Project Structure](#-project-structure)
- [Game Mechanics](#-game-mechanics)
- [Technologies](#-technologies)
- [Controls](#-controls)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

---

## 🎯 About

Game Side Mobile is a 2D platformer designed with a focus on smooth user experience and precise movement mechanics. This project includes advanced systems such as Double Jump, Wall Jump, Coyote Time, and Jump Buffer to provide an enjoyable experience for players.

---

## ✨ Features

### Advanced Movement System
- ✅ **Double Jump** - Ability to jump twice with visual effects
- ✅ **Wall Jump** - Jump off walls with automatic direction change
- ✅ **Coyote Time** - Extra time to jump after falling off an edge
- ✅ **Jump Buffer** - Records jump button press before landing

### Game Systems
- 🎨 Smooth and responsive animations
- ❤️ Player health management system
- 🎭 Visual effects for various actions
- 🎯 Precise and optimized collision detection

### Optimization
- 📱 Designed for mobile platforms
- ⚡ Using URP for optimized rendering
- 🔧 Clean and modular code
- 📊 Efficient resource management

---

## 🔧 Prerequisites

- **Unity 6** (version 6000.2 or higher)
- **Unity Hub** (latest version)
- **Git** for cloning the project
- One of the following IDEs:
  - Visual Studio 2022
  - JetBrains Rider 2023.3+

---

## 🚀 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Taxtander/game-side-mobile.git
cd game-side-mobile
```

### 2. Open in Unity

1. Open Unity Hub
2. Click **Add**
3. Select the project folder
4. Make sure Unity 6 is installed
5. Open the project

### 3. Initial Import

After opening the project:
- Wait for Unity to import all packages
- If errors occur, use **Assets > Reimport All** from the menu

### 4. Run the Game

- Open the `Lv3` scene from `Assets/Scenes/Starter Levels/Levels/`
- Press the Play button

---

## 📁 Project Structure

```
Assets/
├── Scenes/               # Game scenes
│   └── Starter Levels/
│       └── Levels/       # Game levels (Lv1, Lv2, Lv3, ...)
├── Scripts/              # All C# scripts
│   ├── Player/           # Player-related scripts
│   │   ├── PlayerMovement.cs
│   │   ├── PlayerHealthManager.cs
│   │   └── PlayerDoubleJumpEffectScript.cs
│   ├── Enemy/            # Enemy scripts
│   ├── Items/            # Collectible items
│   └── Traps/            # Traps and obstacles
├── Prefabs/              # Game prefabs
│   ├── Player/
│   ├── Enemies/
│   └── Items/
├── Materials/            # Materials and shaders
├── Models/               # 3D models (if any)
└── Sprites/              # Images and sprites
```

---

## 🎮 Game Mechanics

### Movement System (PlayerMovement.cs)

**Configurable Parameters:**
- `Speed`: Horizontal movement speed (default: 6)
- `Jump`: Jump force (default: 12)
- `maxJumpCount`: Number of allowed jumps (default: 2)
- `coyoteTime`: Extra time for jumping (default: 0.15s)
- `jumpBufferTime`: Jump buffer time (default: 0.2s)

**Key Features:**
1. **Coyote Time**: Player can still jump shortly after falling off an edge
2. **Jump Buffer**: Jump button press is recorded before landing
3. **Wall Slide**: Reduced fall speed when touching a wall
4. **Wall Jump**: Jump off walls by pressing Space

### Effects System (PlayerDoubleJumpEffectScript.cs)

- Visual effect display during Double Jump
- Automatic effect count management
- Automatic effect cleanup after specified duration

---

## 🛠 Technologies

### Unity Packages

| Package | Version | Description |
|---------|---------|-------------|
| Unity 2D Animation | 12.0.2 | 2D animation system |
| Unity Input System | 1.14.2 | Input management |
| Universal RP | 17.2.0 | Optimized rendering |
| 2D Sprite | 1.0.0 | Sprite management |
| 2D Tilemap | 1.0.0 | Tilemap system |
| Timeline | 1.8.9 | Cutscenes and animation |

### Render Pipeline

- **URP (Universal Render Pipeline)** for mobile optimization
- Renderer Type: **2D**

### Layers

```
- Default
- Ground
- Wall
- Player
- Enemy
- UI
```

### Tags

```
- Player
- Ground
- Enemy
- Items
- EndItem
```

---

## 🎯 Controls

### Keyboard (for testing in Editor)

| Key | Action |
|-----|--------|
| ← → | Move left/right |
| Space | Jump / Double Jump / Wall Jump |

### Mobile (in development)

- Touch controls for movement
- Virtual button for jumping

---

## 🤝 Contributing

Your contributions to improving this project are greatly appreciated!

### How to Contribute:

1. Fork the project
2. Create a new Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Coding Guidelines:

- Use meaningful names for variables
- Add comments for public methods
- Use const fields instead of hardcoded values
- Place code in appropriate folders:
  - Scripts in `/Assets/Scripts`
  - Materials in `/Assets/Materials`
  - Prefabs in `/Assets/Prefabs`

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 📞 Contact


Project Link: [https://github.com/Taxtander/game-side-mobile](https://github.com/yourusername/game-side-mobile)

---

## 🙏 Acknowledgments

- [Unity Technologies](https://unity.com/) - Game engine
- All developers contributing to Unity packages
- Unity community for tutorials and support

---

<div align="center">

**Made with ❤️ in Unity**

⭐ If this project helped you, give it a star!

</div>
