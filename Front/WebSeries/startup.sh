#!/bin/bash
echo "Configuring Nginx for SPA"
sed -i 's|try_files $uri $uri/ /index.html;|try_files $uri $uri/ /index.html;|' /etc/nginx/sites-available/default
service nginx restart