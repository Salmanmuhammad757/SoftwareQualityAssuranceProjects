from selenium import webdriver
import time

driver = webdriver.Chrome()
driver.maximize_window()
driver.get("https://www.google.com")
time.sleep(3)
inputElement = driver.find_element_by_name("q")
driver.find_element_by_xpath("//a[@id='gb_70']").click()
time.sleep(3)
inputElement = driver.find_element_by_id("identifierId")
inputElement.send_keys("salmanmuhammad0@gmail.com")
driver.find_element_by_xpath("//span[@class='RveJvd snByac']").click()

time.sleep(3)

driver.close()
