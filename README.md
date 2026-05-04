# 🎮 MadOverGames – Unity Game Developer Assignment

This repository contains solutions for the Unity Game Developer Assignment provided by MadOverGames.

---

## 📌 Assignment Overview

### 🔹 1. C# Algorithm – Three Pair Sum

#### Objective
Determine whether:
- A pair of numbers sums to 0
- A triplet of numbers sums to 0

#### Methods

bool IsSumTwoZero(int[] a)
bool IsSumThreeZero(int[] a)

#### Example

Input: [-7, -5, 4, 5, 6]
Pair Sum: True
Triplet Sum: False

Input: [-7, -3, 4, 6, 10, 15]
Pair Sum: False
Triplet Sum: True

#### Approach
- Pair Sum → HashSet (O(n))
- Triplet Sum → Sorting + Two-pointer (O(n²))

---

### 🔹 2. UI – Touch Scroll Menu

#### Objective
Design a scrollable animated UI menu compatible with:
- Mobile (9:16)
- Tablet (3:4)

#### Features
- Smooth scrolling
- Button animations
- Responsive layout
- Grid Layout Group support

#### Tools Used
- Unity UI System
- Scroll Rect
- Animator

---

### 🔹 3. Download Image System

#### Objective
Build a Singleton system to download and manage images efficiently.

#### Components
- DownloadImageManager (Singleton)
- WebImage.cs

#### Features
- Max 3 concurrent downloads
- Timeout override (10 seconds)
- Disk caching (7 days expiry)
- Optional memory caching
- Alpha image support

---

## 🚀 How to Run

1. Clone the repository
2. Open in Unity (2018.4.28f1 or later)
3. Open scenes
4. Play the project

---

## 📦 Deliverables

- Unity Package (.unitypackage)
- Source Code
- README.md

---

## 👨‍💻 Author

Durkesh Kumar S

---

## 🏢 Company

MadOverGames  
340 S Lemon Ave 2882  
Walnut, CA 91789, USA
