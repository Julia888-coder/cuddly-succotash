package com.example.myapplication3

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.activityViewModels
import androidx.navigation.findNavController
import androidx.navigation.ui.AppBarConfiguration
import androidx.navigation.ui.navigateUp
import androidx.navigation.ui.setupActionBarWithNavController
import com.example.myapplication3.LanguageHelper.changeLanguage
import com.example.myapplication3.databinding.ActivityMainBinding
import com.example.myapplication3.entity_info.EntityInfoViewModel
import com.example.myapplication3.report.ReportActivity


class MainActivity : AppCompatActivity() {

    private val mainViewModel: MainActivityViewModel by viewModels()
    private val entityInfoViewModel: EntityInfoViewModel by viewModels()

    private lateinit var appBarConfiguration: AppBarConfiguration
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setSupportActionBar(binding.toolbar)

        binding.fab.setOnClickListener {
            entityInfoViewModel.applyArgs(null)
            findNavController(R.id.nav_host_fragment_content_main)
                .navigate(R.id.action_FirstFragment_to_SecondFragment)
        }

        val navController = findNavController(R.id.nav_host_fragment_content_main)
        appBarConfiguration = AppBarConfiguration(navController.graph)
        setupActionBarWithNavController(navController, appBarConfiguration)
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Inflate the menu; this adds items to the action bar if it is present.
        menuInflater.inflate(R.menu.menu_main, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean =
        when (item.itemId) {
            R.id.action_report   -> {
                val intent = Intent(this, ReportActivity::class.java)
                startActivity(intent)
                true
            }

            R.id.action_language -> {
                changeLanguage()
                true
            }

            R.id.action_import   -> {
                mainViewModel.import(this)
                true
            }

            R.id.action_export   -> {
                mainViewModel.export(this)
                true
            }

            else                 -> super.onOptionsItemSelected(item)
        }

    override fun attachBaseContext(newBase: Context) {
        super.attachBaseContext(LanguageHelper.setLanguage(newBase))
    }

    override fun onSupportNavigateUp(): Boolean {
        val navController = findNavController(R.id.nav_host_fragment_content_main)
        return navController.navigateUp(appBarConfiguration)
                || super.onSupportNavigateUp()
    }
}