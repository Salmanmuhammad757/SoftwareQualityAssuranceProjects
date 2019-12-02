from selenium import webdriver
driver = webdriver.Firefox(executable_path=r'C:\Users\Muhammd Salman\Downloads\geckodriver.exe');
driver.get("http://www.google.com")
driver.close()
