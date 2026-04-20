🧾 Awlad Ali Cashier System
Integrated Point of Sale (POS) & Restaurant Management Solution
Awlad Ali Cashier is a professional Windows-based desktop application designed to streamline restaurant operations. It manages everything from rapid order entry for cashiers to deep financial analytics and inventory control for administrators.

🚀 Key Features
🛒 Intelligent POS Interface: A dynamic menu that allows cashiers to select items, specify sizes (S, M, L, XL), and add extras with real-time price calculation.

📊 Admin Dashboard: Visualizes business performance with metrics like Total Revenue, Order Count, and "Top 6 Best-Selling Products" using clear charts and data grids.

👥 Role-Based Access Control: Secure authentication system with separate permissions for "Admins" and "Cashiers," ensuring sensitive settings stay protected.

📦 Menu & Inventory Management: Full CRUD (Create, Read, Update, Delete) functionality for categories, products, and add-ons.

🔐 Data Security: Uses AES-256 encryption for user passwords and handles failed login attempts via the Windows Event Log.

🧾 Professional Invoicing: Automatically generates detailed receipts for every transaction, including itemized breakdowns and grand totals.

🏛️ Architecture & Design
The system is built using a Three-Tier Architecture, ensuring the code is organized, maintainable, and scalable:

Presentation Layer (UI): Built with WinForms and Material Design for a modern, responsive user experience.

Business Logic Layer (BLL): The "brain" of the app. It handles validation, pricing rules, and coordinates between the UI and the data.

Data Access Layer (DAL): Manages all communication with the database using optimized SQL queries.

Why this matters: This separation ensures that business rules are independent of the user interface, making the system robust and easy to update.

🛠️ Technology Stack
Language: C# (.NET Framework)

Database: SQLite (Lightweight, serverless, and high-performance)

UI Framework: MaterialSkin 2.0 (Google Material Design for WinForms)

Security: System.Security.Cryptography (AES-256)

Architecture: Three-Tier Pattern (UI → BLL → DAL)

🗃️ Database Overview
The system utilizes a relational database structure to maintain data integrity:

Users: Stores encrypted credentials and roles.

Products & Categories: Organized hierarchy for the restaurant menu.

Product Sizes: Supports flexible pricing based on item size.

Orders & Order Details: Atomic logging of every transaction and its specific line items.

⚙️ How It Works
Authentication: Users log in; the system detects their role and adjusts the interface accordingly.

Order Entry: The cashier picks items; the system handles complex logic (like size-specific pricing) automatically.

Persistence: On saving, the system performs an atomic transaction to ensure the order and its details are saved correctly to the SQLite database.

Reporting: Admins use date filters to fetch real-time analytics from the database to monitor restaurant growth.

👨‍💻 Developed By
Mohamed Abdel-Tawab
Computer Science Student - Level 3
Focused on building clean, architecturally sound software using industry-standard design patterns.





=========================================================================================



🧾 Awlad Ali Cashier System
نظام متكامل لإدارة المطاعم والمبيعات والمخازن
مشروع Awlad Ali Cashier هو تطبيق سطح مكتب (Windows) مصمم خصيصاً لإدارة عمليات البيع في المطاعم بشكل سريع ودقيق. البرنامج بيغطي كل حاجة، بداية من تسجيل دخول الموظفين، مروراً بطلب الأوردرات، وصولاً لتقارير الأرباح والمبيعات المفصلة.

🚀 المميزات الرئيسية (ماذا يقدم البرنامج؟)
🛒 واجهة كاشير ذكية: شاشة تفاعلية تتيح اختيار الأصناف، تحديد الأحجام (S, M, L, XL)، وإضافة الإضافات (Extras) مع تحديث فوري لإجمالي السعر.

📊 لوحة تحكم الأدمن (Dashboard): عرض سريع لإجمالي الأرباح، عدد الأوردرات، وأكثر 6 منتجات مبيعاً من خلال رسوم بيانية وتقارير واضحة.

👥 إدارة الموظفين والصلاحيات: نظام أمان قوي يسمح بإضافة "كاشير" أو "مدير"، مع تشفير كلمات المرور لضمان الخصوصية.

📦 إدارة المخزن والمنيو: التحكم الكامل في إضافة أو تعديل أو حذف الأقسام والمنتجات والأسعار بكل سهولة.

🧾 طباعة الفواتير: إصدار فاتورة مفصلة لكل أوردر تحتوي على كافة التفاصيل (الكمية، الحجم، السعر الإجمالي).

💾 نظام حفظ البيانات: تخزين تلقائي لكل العمليات في قاعدة بيانات محلية (SQLite) سريعة ومستقرة.

🏗️ كيف تم بناء البرنامج؟ (Architecture)
تم تصميم البرنامج باستخدام هندسة الطبقات الثلاث (Three-Tier Architecture)، وده معناه إن البرنامج مقسم لـ 3 أجزاء منفصلة تماماً:

واجهة المستخدم (UI): الأشكال والأزرار اللي بيشوفها المستخدم.

منطق العمل (Business Logic): "عقل" البرنامج اللي بيحسب الحسابات ويطبق القواعد.

الوصول للبيانات (Data Access): المسؤول عن التحدث مع قاعدة البيانات وحفظ المعلومات.

الفائدة: هذا التصميم يضمن أن البرنامج سهل التطوير مستقبلاً، وسهل الصيانة، ومنظم جداً برمجياً.

🛠️ الأدوات المستخدمة (Tech Stack)
لغة البرمجة: #C (سي شارب).

بيئة العمل: .NET Framework.

قاعدة البيانات: SQLite (تتميز بالسرعة ولا تحتاج لسيرفر خارجي).

التصميم: MaterialSkin (لإعطاء واجهة عصرية تشبه تطبيقات جوجل).

الأمان: تشفير AES-256 لحماية بيانات المستخدمين.

📂 هيكل قاعدة البيانات (Database)
البرنامج بيتعامل مع عدة جداول مترابطة بذكاء لضمان دقة البيانات:

المستخدمين (Users): لحفظ بيانات الدخول والصلاحيات.

المنتجات والأقسام (Products & Categories): لتنظيم المنيو.

الأحجام والأسعار (Product Sizes): لدعم فكرة اختلاف سعر الصنف حسب الحجم.

الأوردرات (Orders & Details): لحفظ كل عملية بيع تمت بالتفصيل.

⚙️ كيف يعمل البرنامج؟ (Process Flow)
تسجيل الدخول: يقوم الموظف بإدخال بياناته، وإذا كان "أدمن" تفتح له كامل الصلاحيات.

طلب أوردر: يختار الكاشير الأصناف، ويقوم النظام بحساب الإجمالي آلياً.

الحفظ والطباعة: بمجرد الضغط على "حفظ"، يتم تسجيل الأوردر في قاعدة البيانات وعرض الفاتورة فوراً.

المتابعة: يمكن للمدير في أي وقت اختيار "فترة زمنية" (مثلاً آخر 7 أيام) لمتابعة سير العمل والأرباح.

👨‍💻 مطور المشروع : Mohamed Abdeltawab
