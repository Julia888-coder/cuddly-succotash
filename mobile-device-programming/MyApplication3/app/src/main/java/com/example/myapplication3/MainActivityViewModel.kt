package com.example.myapplication3

import android.content.Context
import android.widget.Toast
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.myapplication3.db.EntityEntity
import kotlinx.coroutines.launch
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

class MainActivityViewModel : ViewModel() {
    private val entityDao = AppSingleton.appDatabase.entitiesDao()
    private val json by lazy { Json { prettyPrint = true } }

    fun import(context: Context) {
        val myJson = context.openFileInput(JSON_FILE_NAME).use {
            it.readBytes().decodeToString()
        }
        val entities = json.decodeFromString<List<EntityEntity>>(myJson)
        viewModelScope.launch {
            entityDao.reset(entities)
            Toast.makeText(context, R.string.success_import_json, Toast.LENGTH_SHORT)
                .show()
        }
    }

    fun export(context: Context) {
        viewModelScope.launch {
            val entities = entityDao.getEntitiesList()
            val myJson = json.encodeToString(entities)
            context.openFileOutput(JSON_FILE_NAME, Context.MODE_PRIVATE).use {
                it.write(myJson.toByteArray())
                Toast.makeText(context, R.string.success_export_json, Toast.LENGTH_SHORT)
                    .show()
            }
        }
    }

    private companion object {
        private const val JSON_FILE_NAME = "my_json"
    }
}