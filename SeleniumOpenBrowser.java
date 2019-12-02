/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package seleniumopenbrowser;
import org.openqa.selenium.WebDriver;  
import org.openqa.selenium.firefox.FirefoxDriver;
/**
 *
 * @author Muhammd Salman
 */
public class SeleniumOpenBrowser {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        System.setProperty("webdriver.gecko.driver", "C:\\Users\\Muhammd Salman\\Downloads\\geckodriver.exe");
 
        WebDriver driver  = new FirefoxDriver();
 
        driver.get("http://www.google.com");
        driver.quit();  // using QUIT all windows will close
    }
    
}
