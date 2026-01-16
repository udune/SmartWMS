## Cell의 Control 버튼을 클릭했을때 나타날 윈도우 UI

<!DOCTYPE html>

<html class="light" lang="en"><head>
<meta charset="utf-8"/>
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<title>Cell Environment Configuration</title>
<!-- Fonts -->
<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&amp;display=swap" rel="stylesheet"/>
<!-- Material Symbols -->
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:wght,FILL@100..700,0..1&amp;display=swap" rel="stylesheet"/>
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:wght,FILL@100..700,0..1&amp;display=swap" rel="stylesheet"/>
<!-- Tailwind CSS -->
<script src="https://cdn.tailwindcss.com?plugins=forms,container-queries"></script>
<!-- Theme Config -->
<script id="tailwind-config">
        tailwind.config = {
            darkMode: "class",
            theme: {
                extend: {
                    colors: {
                        "primary": "#137fec",
                        "background-light": "#f6f7f8",
                        "background-dark": "#101922",
                    },
                    fontFamily: {
                        "display": ["Inter", "sans-serif"]
                    },
                    borderRadius: {"DEFAULT": "0.25rem", "lg": "0.5rem", "xl": "0.75rem", "full": "9999px"},
                },
            },
        }
    </script>
</head>
<body class="bg-background-light dark:bg-background-dark font-display text-gray-900 dark:text-gray-100 min-h-screen flex flex-col items-center justify-center p-4 sm:p-6 lg:p-8">
<!-- Modal/Panel Container -->
<div class="w-full max-w-[1000px] h-auto max-h-[90vh] flex flex-col bg-white dark:bg-gray-900 rounded-xl shadow-2xl overflow-hidden border border-gray-200 dark:border-gray-800">
<!-- Header -->
<header class="flex items-center justify-between px-6 py-4 border-b border-gray-100 dark:border-gray-800 bg-white dark:bg-gray-900 sticky top-0 z-10">
<div class="flex items-center gap-4">
<div class="flex items-center justify-center w-10 h-10 rounded-lg bg-primary/10 text-primary">
<span class="material-symbols-outlined">sensors</span>
</div>
<div>
<h2 class="text-lg font-bold leading-tight tracking-tight text-gray-900 dark:text-white flex items-center gap-2">
                        Configuration: Cell A01
                        <span class="relative flex h-3 w-3">
<span class="animate-ping absolute inline-flex h-full w-full rounded-full bg-green-400 opacity-75"></span>
<span class="relative inline-flex rounded-full h-3 w-3 bg-green-500"></span>
</span>
</h2>
<p class="text-xs text-gray-500 dark:text-gray-400 font-medium">Zone 4 • Semiconductor Storage</p>
</div>
</div>
<button class="flex items-center justify-center w-8 h-8 rounded-lg hover:bg-gray-100 dark:hover:bg-gray-800 text-gray-500 transition-colors">
<span class="material-symbols-outlined">close</span>
</button>
</header>
<!-- Main Content (Scrollable) -->
<div class="flex-1 overflow-y-auto custom-scrollbar">
<div class="p-6 space-y-8">
<!-- Stats Section -->
<section>
<h3 class="text-sm font-semibold text-gray-900 dark:text-white uppercase tracking-wider mb-4">Current Conditions</h3>
<div class="grid grid-cols-1 md:grid-cols-2 gap-4">
<!-- Temp Card -->
<div class="flex flex-col gap-1 rounded-xl p-5 border border-gray-200 dark:border-gray-700 bg-gray-50 dark:bg-gray-800/50">
<div class="flex items-center justify-between">
<div class="flex items-center gap-2 text-gray-600 dark:text-gray-400">
<span class="material-symbols-outlined text-[20px]">thermostat</span>
<span class="text-sm font-medium">Temperature (°C)</span>
</div>
<span class="px-2 py-1 rounded text-xs font-bold bg-green-100 text-green-700 dark:bg-green-900/30 dark:text-green-400">Within Range</span>
</div>
<div class="mt-2 flex items-baseline gap-2">
<span class="text-3xl font-bold text-gray-900 dark:text-white">22.4°</span>
<span class="text-sm text-gray-500 dark:text-gray-400 font-medium">/ Target: 22.0°</span>
</div>
<p class="text-sm text-green-600 dark:text-green-400 mt-1 font-medium flex items-center gap-1">
<span class="material-symbols-outlined text-[16px]">trending_up</span>
                                +0.4 (Acceptable)
                            </p>
</div>
<!-- Humidity Card -->
<div class="flex flex-col gap-1 rounded-xl p-5 border border-gray-200 dark:border-gray-700 bg-gray-50 dark:bg-gray-800/50">
<div class="flex items-center justify-between">
<div class="flex items-center gap-2 text-gray-600 dark:text-gray-400">
<span class="material-symbols-outlined text-[20px]">water_drop</span>
<span class="text-sm font-medium">Humidity (%)</span>
</div>
<span class="px-2 py-1 rounded text-xs font-bold bg-blue-100 text-blue-700 dark:bg-blue-900/30 dark:text-blue-400">Optimal</span>
</div>
<div class="mt-2 flex items-baseline gap-2">
<span class="text-3xl font-bold text-gray-900 dark:text-white">45%</span>
<span class="text-sm text-gray-500 dark:text-gray-400 font-medium">/ Target: 45%</span>
</div>
<p class="text-sm text-gray-500 dark:text-gray-400 mt-1 font-medium flex items-center gap-1">
<span class="material-symbols-outlined text-[16px]">remove</span>
                                0.0 deviation
                            </p>
</div>
</div>
</section>
<!-- Settings Form -->
<section>
<div class="flex items-center justify-between mb-4">
<h3 class="text-sm font-semibold text-gray-900 dark:text-white uppercase tracking-wider">Environment Settings</h3>
<button class="text-primary hover:text-blue-600 text-sm font-medium">Reset to Default</button>
</div>
<div class="bg-white dark:bg-gray-800 border border-gray-200 dark:border-gray-700 rounded-xl p-5 space-y-6">
<!-- Temp Settings -->
<div class="grid grid-cols-1 sm:grid-cols-2 gap-6">
<label class="flex flex-col gap-2">
<span class="text-sm font-medium text-gray-700 dark:text-gray-300">Target Temperature (°C)</span>
<div class="relative">
<input class="w-full rounded-lg border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-white focus:border-primary focus:ring-primary h-11 px-3 shadow-sm transition-colors" type="number" value="22.0"/>
<div class="absolute inset-y-0 right-0 flex items-center pr-3 pointer-events-none text-gray-400">
<span class="text-xs">°C</span>
</div>
</div>
</label>
<label class="flex flex-col gap-2">
<span class="text-sm font-medium text-gray-700 dark:text-gray-300">Temp Tolerance (±)</span>
<div class="relative">
<input class="w-full rounded-lg border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-white focus:border-primary focus:ring-primary h-11 px-3 shadow-sm transition-colors" type="number" value="0.5"/>
<div class="absolute inset-y-0 right-0 flex items-center pr-3 pointer-events-none text-gray-400">
<span class="text-xs">°C</span>
</div>
</div>
</label>
</div>
<hr class="border-gray-100 dark:border-gray-700"/>
<!-- Humidity Settings -->
<div class="grid grid-cols-1 sm:grid-cols-2 gap-6">
<label class="flex flex-col gap-2">
<span class="text-sm font-medium text-gray-700 dark:text-gray-300">Target Humidity (%)</span>
<div class="relative">
<input class="w-full rounded-lg border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-white focus:border-primary focus:ring-primary h-11 px-3 shadow-sm transition-colors" type="number" value="45.0"/>
<div class="absolute inset-y-0 right-0 flex items-center pr-3 pointer-events-none text-gray-400">
<span class="text-xs">%</span>
</div>
</div>
</label>
<label class="flex flex-col gap-2">
<span class="text-sm font-medium text-gray-700 dark:text-gray-300">Humidity Tolerance (±)</span>
<div class="relative">
<input class="w-full rounded-lg border-gray-300 dark:border-gray-600 bg-white dark:bg-gray-900 text-gray-900 dark:text-white focus:border-primary focus:ring-primary h-11 px-3 shadow-sm transition-colors" type="number" value="2.0"/>
<div class="absolute inset-y-0 right-0 flex items-center pr-3 pointer-events-none text-gray-400">
<span class="text-xs">%</span>
</div>
</div>
</label>
</div>
<hr class="border-gray-100 dark:border-gray-700"/>
<!-- Light Control -->
<div class="flex items-center justify-between">
<div class="flex flex-col">
<span class="text-sm font-medium text-gray-900 dark:text-white">Light Exposure Control</span>
<span class="text-xs text-gray-500 dark:text-gray-400">Block external light for sensitive materials</span>
</div>
<label class="relative inline-flex items-center cursor-pointer">
<input checked="" class="sr-only peer" type="checkbox" value=""/>
<div class="w-11 h-6 bg-gray-200 peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-blue-100 dark:peer-focus:ring-blue-800/30 rounded-full peer dark:bg-gray-700 peer-checked:after:translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all dark:border-gray-600 peer-checked:bg-primary"></div>
<span class="ml-3 text-sm font-medium text-gray-900 dark:text-white">Blocked</span>
</label>
</div>
</div>
</section>
<!-- History Section -->
<section>
<h3 class="text-sm font-semibold text-gray-900 dark:text-white uppercase tracking-wider mb-4">Alert History (Last 24h)</h3>
<div class="overflow-hidden rounded-xl border border-gray-200 dark:border-gray-700">
<table class="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
<thead class="bg-gray-50 dark:bg-gray-800">
<tr>
<th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-400 uppercase tracking-wider" scope="col">Time</th>
<th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-400 uppercase tracking-wider" scope="col">Event</th>
<th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-400 uppercase tracking-wider" scope="col">Value</th>
<th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-400 uppercase tracking-wider" scope="col">Status</th>
</tr>
</thead>
<tbody class="bg-white dark:bg-gray-900 divide-y divide-gray-200 dark:divide-gray-800">
<tr>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">10:42 AM</td>
<td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900 dark:text-white">Humidity Spike</td>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">48%</td>
<td class="px-6 py-4 whitespace-nowrap">
<span class="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-400">
                                            Resolved
                                        </span>
</td>
</tr>
<tr>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">08:15 AM</td>
<td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900 dark:text-white">Temp Low</td>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">21.2°C</td>
<td class="px-6 py-4 whitespace-nowrap">
<span class="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-medium bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-400">
                                            Resolved
                                        </span>
</td>
</tr>
<tr>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">Yesterday</td>
<td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900 dark:text-white">Maintenance</td>
<td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">-</td>
<td class="px-6 py-4 whitespace-nowrap">
<span class="inline-flex items-center gap-1 px-2.5 py-0.5 rounded-full text-xs font-medium bg-gray-100 text-gray-800 dark:bg-gray-800 dark:text-gray-300">
                                            Log
                                        </span>
</td>
</tr>
</tbody>
</table>
</div>
</section>
</div>
</div>
<!-- Footer Actions -->
<div class="px-6 py-4 border-t border-gray-100 dark:border-gray-800 bg-gray-50 dark:bg-gray-900/50 flex justify-end gap-3 sticky bottom-0">
<button class="px-4 py-2 text-sm font-medium text-gray-700 dark:text-gray-300 bg-white dark:bg-gray-800 border border-gray-300 dark:border-gray-600 rounded-lg hover:bg-gray-50 dark:hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary transition-colors">
                Cancel
            </button>
<button class="px-4 py-2 text-sm font-bold text-white bg-primary rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary shadow-sm transition-colors flex items-center gap-2">
<span class="material-symbols-outlined text-[18px]">check</span>
                Apply Changes
            </button>
</div>
</div>
</body></html>

## 메인 대시보드에서 List View로 전환했을때의 UI
<!DOCTYPE html>
<html class="light" lang="en"><head>
<meta charset="utf-8"/>
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<title>Smart WMS Dashboard - List View</title>
<link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;900&amp;display=swap" rel="stylesheet"/>
<link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:wght,FILL@100..700,0..1&amp;display=swap" rel="stylesheet"/>
<script src="https://cdn.tailwindcss.com?plugins=forms,container-queries"></script>
<script id="tailwind-config">
        tailwind.config = {
            darkMode: "class",
            theme: {
                extend: {
                    colors: {
                        "primary": "#137fec",
                        "background-light": "#f8fafc", 
                        "background-dark": "#0f172a",
                    },
                    fontFamily: {
                        "display": ["Inter", "sans-serif"]
                    },
                    borderRadius: {"DEFAULT": "0.375rem", "lg": "0.5rem", "xl": "0.75rem", "full": "9999px"},
                },
            },
        }
    </script>
<style type="text/tailwindcss">
        ::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }
        ::-webkit-scrollbar-track {
            background: transparent;
        }
        ::-webkit-scrollbar-thumb {
            background: #cbd5e1;
            border-radius: 4px;
        }
        ::-webkit-scrollbar-thumb:hover {
            background: #94a3b8;
        }
        .dark ::-webkit-scrollbar-thumb {
            background: #334155;
        }
        .table-row-alert {
            @apply bg-red-50/50 dark:bg-red-900/10;
        }
        .table-row-warning {
            @apply bg-amber-50/50 dark:bg-amber-900/10;
        }
        .table-row-active {
            @apply bg-blue-50/50 dark:bg-blue-900/10;
        }
    </style>
</head>
<body class="bg-background-light dark:bg-background-dark text-slate-900 dark:text-slate-100 font-display antialiased overflow-hidden h-screen w-full flex">
<aside class="w-64 bg-white dark:bg-[#1a2632] border-r border-slate-200 dark:border-slate-800 flex flex-col shrink-0 transition-colors duration-200">
<div class="p-6">
<div class="flex items-center gap-3 mb-10">
<div class="w-8 h-8 rounded bg-primary flex items-center justify-center text-white">
<span class="material-symbols-outlined text-[20px]">memory</span>
</div>
<div>
<h1 class="text-base font-bold leading-tight tracking-tight text-slate-900 dark:text-white">Smart WMS</h1>
<p class="text-xs text-slate-500 dark:text-slate-400 font-medium">Semiconductor Mgmt</p>
</div>
</div>
<nav class="flex flex-col gap-1.5">
<a class="flex items-center gap-3 px-3 py-2.5 rounded-lg bg-primary/10 text-primary dark:bg-primary/20 dark:text-blue-400 group" href="#">
<span class="material-symbols-outlined text-[22px]">grid_view</span>
<span class="text-sm font-semibold">Dashboard</span>
</a>
<a class="flex items-center gap-3 px-3 py-2.5 rounded-lg text-slate-600 hover:bg-slate-50 hover:text-slate-900 dark:text-slate-400 dark:hover:bg-slate-800 dark:hover:text-slate-200 transition-colors group" href="#">
<span class="material-symbols-outlined text-[22px]">inventory_2</span>
<span class="text-sm font-medium">Inventory</span>
</a>
<a class="flex items-center gap-3 px-3 py-2.5 rounded-lg text-slate-600 hover:bg-slate-50 hover:text-slate-900 dark:text-slate-400 dark:hover:bg-slate-800 dark:hover:text-slate-200 transition-colors group" href="#">
<span class="material-symbols-outlined text-[22px]">analytics</span>
<span class="text-sm font-medium">Reports</span>
</a>
<a class="flex items-center gap-3 px-3 py-2.5 rounded-lg text-slate-600 hover:bg-slate-50 hover:text-slate-900 dark:text-slate-400 dark:hover:bg-slate-800 dark:hover:text-slate-200 transition-colors group" href="#">
<span class="material-symbols-outlined text-[22px]">settings</span>
<span class="text-sm font-medium">Settings</span>
</a>
</nav>
</div>
<div class="mt-auto p-4 border-t border-slate-200 dark:border-slate-800">
<div class="flex items-center gap-3 px-3 py-3 rounded-lg border border-slate-100 dark:border-slate-700 bg-slate-50/50 dark:bg-slate-800/50">
<div class="w-8 h-8 rounded-full bg-slate-200 dark:bg-slate-600 flex items-center justify-center shrink-0">
<span class="material-symbols-outlined text-sm text-slate-500 dark:text-slate-300">person</span>
</div>
<div class="overflow-hidden">
<p class="text-xs font-bold text-slate-900 dark:text-white truncate">Admin User</p>
<p class="text-[10px] text-slate-500 dark:text-slate-400 truncate">admin@smartwms.com</p>
</div>
</div>
</div>
</aside>
<main class="flex-1 flex flex-col min-w-0 overflow-hidden">
<header class="bg-white dark:bg-[#1a2632] border-b border-slate-200 dark:border-slate-800 sticky top-0 z-10 shrink-0">
<div class="px-8 py-5 flex items-center justify-between">
<div>
<h2 class="text-xl font-bold text-slate-900 dark:text-white tracking-tight">Real-time Cell &amp; Environment Monitor</h2>
<p class="text-xs text-slate-500 dark:text-slate-400 mt-1 flex items-center gap-2">
<span class="flex h-2 w-2 rounded-full bg-emerald-500"></span>
<span class="font-medium text-emerald-600 dark:text-emerald-400 uppercase tracking-wider text-[10px]">SignalR Connected</span>
<span class="text-slate-300 dark:text-slate-600">•</span>
<span>Zone A - High Precision Storage</span>
</p>
</div>
<div class="flex items-center gap-4">
<div class="flex items-center gap-1 bg-slate-100 dark:bg-slate-800 p-1 rounded-lg border border-slate-200 dark:border-slate-700">
<button class="px-4 py-1.5 rounded-md text-xs font-medium text-slate-500 dark:text-slate-400 hover:text-slate-700 dark:hover:text-slate-200 transition-colors">Grid View</button>
<button class="px-4 py-1.5 rounded-md bg-white dark:bg-slate-700 shadow-sm text-xs font-bold text-primary dark:text-blue-400 border border-slate-200 dark:border-slate-600">List View</button>
</div>
<button class="relative p-2 text-slate-500 hover:text-primary transition-colors">
<span class="material-symbols-outlined">notifications</span>
<span class="absolute top-1.5 right-1.5 w-2 h-2 bg-red-500 rounded-full border border-white dark:border-[#1a2632]"></span>
</button>
</div>
</div>
</header>
<div class="flex-1 overflow-y-auto bg-slate-50/50 dark:bg-background-dark p-8">
<div class="max-w-7xl mx-auto flex flex-col gap-6">
<div class="flex flex-wrap items-center justify-between gap-4">
<div class="flex items-center gap-3">
<div class="relative group">
<span class="material-symbols-outlined absolute left-3 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-primary text-[20px]">search</span>
<input class="pl-10 pr-4 py-2 w-72 text-sm bg-white dark:bg-[#1a2632] border border-slate-200 dark:border-slate-700 rounded-lg focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all placeholder:text-slate-400 text-slate-900 dark:text-white shadow-sm" placeholder="Search cell, material, or batch..." type="text"/>
</div>
<select class="pl-3 pr-8 py-2 text-sm bg-white dark:bg-[#1a2632] border border-slate-200 dark:border-slate-700 rounded-lg focus:ring-2 focus:ring-primary/20 focus:border-primary outline-none transition-all text-slate-600 dark:text-slate-300 shadow-sm">
<option>All Zones</option>
<option>Zone A (Wafer)</option>
<option>Zone B (Chemical)</option>
</select>
</div>
<div class="flex items-center gap-4 text-[11px] text-slate-500 dark:text-slate-400 font-semibold bg-white dark:bg-[#1a2632] px-4 py-2 rounded-lg border border-slate-200 dark:border-slate-700 shadow-sm">
<div class="flex items-center gap-1.5">
<span class="w-2 h-2 rounded-full bg-emerald-500"></span> Normal
                    </div>
<div class="flex items-center gap-1.5">
<span class="w-2 h-2 rounded-full bg-red-500"></span> Alert
                    </div>
<div class="flex items-center gap-1.5">
<span class="w-2 h-2 rounded-full bg-blue-500"></span> Robot Active
                    </div>
</div>
</div>
<div class="bg-white dark:bg-[#1a2632] rounded-xl border border-slate-200 dark:border-slate-800 shadow-sm overflow-hidden">
<table class="w-full text-left border-collapse">
<thead>
<tr class="bg-slate-50 dark:bg-slate-800/50 border-b border-slate-200 dark:border-slate-800">
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider">Cell ID</th>
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider">Status</th>
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider">Material</th>
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider">Temperature</th>
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider">Humidity</th>
<th class="px-6 py-4 text-[11px] font-bold text-slate-500 dark:text-slate-400 uppercase tracking-wider text-right">Actions</th>
</tr>
</thead>
<tbody class="divide-y divide-slate-100 dark:divide-slate-800">
<tr class="hover:bg-slate-50/80 dark:hover:bg-slate-800/30 transition-colors">
<td class="px-6 py-4">
<span class="px-2.5 py-1 rounded bg-slate-100 dark:bg-slate-800 border border-slate-200 dark:border-slate-700 text-xs font-bold text-slate-700 dark:text-slate-300">A01</span>
</td>
<td class="px-6 py-4">
<span class="inline-flex items-center gap-1.5 px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wide bg-emerald-50 text-emerald-700 dark:bg-emerald-900/20 dark:text-emerald-400 border border-emerald-100 dark:border-emerald-800">
<span class="w-1.5 h-1.5 rounded-full bg-emerald-500"></span> OK
                                </span>
</td>
<td class="px-6 py-4">
<div class="flex items-center gap-3">
<span class="material-symbols-outlined text-primary text-[20px]">texture</span>
<div>
<p class="text-sm font-bold text-slate-900 dark:text-white">Silicon Wafer 300mm</p>
<p class="text-[10px] text-slate-500 dark:text-slate-400">ID: MAT-00124 • Batch B-12</p>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-900 dark:text-white">23.0°C</span>
<span class="text-[10px] font-medium text-emerald-600 uppercase">Optimal</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-emerald-500 w-[45%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-900 dark:text-white">45%</span>
<span class="text-[10px] font-medium text-blue-600 uppercase">Optimal</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-blue-500 w-[50%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4 text-right">
<button class="inline-flex items-center gap-1.5 px-3 py-1.5 bg-white dark:bg-slate-700 border border-slate-200 dark:border-slate-600 rounded text-xs font-bold text-slate-700 dark:text-white hover:border-primary hover:text-primary transition-all">
<span class="material-symbols-outlined text-[16px]">tune</span> Control
                                </button>
</td>
</tr>
<tr class="table-row-alert hover:bg-red-50 dark:hover:bg-red-900/20 transition-colors">
<td class="px-6 py-4">
<span class="px-2.5 py-1 rounded bg-red-100 dark:bg-red-900/30 border border-red-200 dark:border-red-800 text-xs font-bold text-red-700 dark:text-red-400">A02</span>
</td>
<td class="px-6 py-4">
<span class="inline-flex items-center gap-1.5 px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wide bg-red-600 text-white shadow-sm">
<span class="material-symbols-outlined text-[14px]">warning</span> Alert
                                </span>
</td>
<td class="px-6 py-4">
<div class="flex items-center gap-3">
<span class="material-symbols-outlined text-amber-600 dark:text-amber-400 text-[20px]">science</span>
<div>
<p class="text-sm font-bold text-slate-900 dark:text-white">Photoresist PR-500</p>
<p class="text-[10px] text-red-500 dark:text-red-400 font-medium">Expiring Soon • ID: CHE-08921</p>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-red-600 dark:text-red-400">26.5°C</span>
<span class="text-[10px] font-bold text-red-600 uppercase">Critical</span>
</div>
<div class="w-24 h-1 bg-red-100 dark:bg-red-900/30 rounded-full overflow-hidden">
<div class="h-full bg-red-500 w-[75%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-900 dark:text-white">48%</span>
<span class="text-[10px] font-medium text-emerald-600 uppercase">Stable</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-blue-500 w-[55%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4 text-right">
<button class="inline-flex items-center gap-1.5 px-3 py-1.5 bg-red-600 text-white rounded text-xs font-bold hover:bg-red-700 transition-all shadow-sm">
<span class="material-symbols-outlined text-[16px]">tune</span> Adjust
                                </button>
</td>
</tr>
<tr class="table-row-active hover:bg-blue-50 dark:hover:bg-blue-900/20 transition-colors">
<td class="px-6 py-4">
<span class="px-2.5 py-1 rounded bg-blue-100 dark:bg-blue-900/30 border border-blue-200 dark:border-blue-800 text-xs font-bold text-blue-700 dark:text-blue-400">B01</span>
</td>
<td class="px-6 py-4">
<span class="inline-flex items-center gap-1.5 px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wide bg-blue-600 text-white">
<span class="material-symbols-outlined text-[14px]">smart_toy</span> Robotic
                                </span>
</td>
<td class="px-6 py-4">
<div class="flex items-center gap-3">
<span class="material-symbols-outlined text-blue-500 animate-spin text-[20px]">settings</span>
<div>
<p class="text-sm font-bold text-slate-900 dark:text-white">Assembly Kit Z-10</p>
<p class="text-[10px] text-blue-600 dark:text-blue-400 font-medium">Action: Retrieving...</p>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-900 dark:text-white">22.0°C</span>
<span class="text-[10px] font-medium text-emerald-600 uppercase">Optimal</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-emerald-500 w-[42%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-900 dark:text-white">42%</span>
<span class="text-[10px] font-medium text-emerald-600 uppercase">Optimal</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-blue-500 w-[45%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4 text-right">
<button class="inline-flex items-center gap-1.5 px-3 py-1.5 bg-slate-100 dark:bg-slate-800 border border-slate-200 dark:border-slate-700 rounded text-xs font-bold text-slate-400 dark:text-slate-500 cursor-not-allowed">
<span class="material-symbols-outlined text-[16px]">lock</span> Locked
                                </button>
</td>
</tr>
<tr class="hover:bg-slate-50/80 dark:hover:bg-slate-800/30 transition-colors">
<td class="px-6 py-4">
<span class="px-2.5 py-1 rounded bg-slate-100 dark:bg-slate-800 border border-slate-200 dark:border-slate-700 text-xs font-bold text-slate-500 dark:text-slate-400">B02</span>
</td>
<td class="px-6 py-4">
<span class="inline-flex items-center gap-1.5 px-2 py-0.5 rounded-full text-[10px] font-bold uppercase tracking-wide bg-slate-100 text-slate-600 dark:bg-slate-800 dark:text-slate-400 border border-slate-200 dark:border-slate-700">
<span class="w-1.5 h-1.5 rounded-full bg-slate-400"></span> Empty
                                </span>
</td>
<td class="px-6 py-4">
<div class="flex items-center gap-3">
<span class="material-symbols-outlined text-slate-300 dark:text-slate-600 text-[20px]">check_box_outline_blank</span>
<div>
<p class="text-sm font-bold text-slate-400 dark:text-slate-500 italic">No Material</p>
<p class="text-[10px] text-slate-400 dark:text-slate-500">Ready for storage</p>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-600 dark:text-slate-400">21.0°C</span>
<span class="text-[10px] font-medium text-slate-400 uppercase">Idle</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-slate-400 w-[40%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4">
<div class="flex flex-col gap-1">
<div class="flex items-center justify-between gap-4">
<span class="text-sm font-bold text-slate-600 dark:text-slate-400">40%</span>
<span class="text-[10px] font-medium text-slate-400 uppercase">Idle</span>
</div>
<div class="w-24 h-1 bg-slate-100 dark:bg-slate-700 rounded-full overflow-hidden">
<div class="h-full bg-slate-400 w-[40%]"></div>
</div>
</div>
</td>
<td class="px-6 py-4 text-right">
<button class="inline-flex items-center gap-1.5 px-3 py-1.5 bg-white dark:bg-slate-700 border border-slate-200 dark:border-slate-600 rounded text-xs font-bold text-slate-700 dark:text-white hover:border-primary hover:text-primary transition-all">
<span class="material-symbols-outlined text-[16px]">tune</span> Control
                                </button>
</td>
</tr>
</tbody>
</table>
</div>
<div class="flex items-center justify-between text-xs text-slate-500 dark:text-slate-400 font-medium px-2">
<p>Showing 1 to 4 of 124 cells in Zone A &amp; B</p>
<div class="flex gap-2">
<button class="px-3 py-1.5 rounded bg-white dark:bg-[#1a2632] border border-slate-200 dark:border-slate-700 hover:bg-slate-50 dark:hover:bg-slate-800 disabled:opacity-50">Previous</button>
<button class="px-3 py-1.5 rounded bg-white dark:bg-[#1a2632] border border-slate-200 dark:border-slate-700 hover:bg-slate-50 dark:hover:bg-slate-800">Next</button>
</div>
</div>
</div>
</div>
</main>

</body></html>