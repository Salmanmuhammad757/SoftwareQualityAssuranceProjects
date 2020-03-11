from selenium import webdriver
driver = webdriver.Firefox(executable_path='geckodriver.exe');
driver.get("http://www.facebook.com")
driver.find_element_by_id('email').send_keys('salman@testing.com')
driver.find_element_by_id('pass').send_keys('password1')
driver.find_element_by_id('loginbutton').click()
driver.close()
